using EmployeeManagementServiceBAL;
using EmployeeManagementServiceModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementPL
{
    public partial class EmployeeWebForm : System.Web.UI.Page
    {
        private readonly EmployeeLinqBAL _bal = new EmployeeLinqBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            var employees = _bal.GetAllEmployees();
            gvEmployees.DataSource = employees;
            gvEmployees.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(txtHireDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime hireDate))
            {
                // You can add user notification logic here
                return;
            }

            var emp = new Employee
            {
                EmployeeId = string.IsNullOrEmpty(hfEmployeeId.Value) ? 0 : int.Parse(hfEmployeeId.Value),
                EmployeeName = txtName.Text.Trim(),
                Department = txtDepartment.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HireDate = hireDate
            };

            if (emp.EmployeeId == 0)
                _bal.AddEmployee(emp);
            else
                _bal.ModifyEmployee(emp);

            ClearForm();
            LoadEmployees();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            hfEmployeeId.Value = string.Empty;
            txtName.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHireDate.Text = string.Empty;
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int employeeId = Convert.ToInt32(gvEmployees.DataKeys[index].Value);

            if (e.CommandName == "EditRow")
            {
                var employee = _bal.GetEmployee(employeeId);
                if (employee != null)
                {
                    hfEmployeeId.Value = employee.EmployeeId.ToString();
                    txtName.Text = employee.EmployeeName;
                    txtDepartment.Text = employee.Department;
                    txtEmail.Text = employee.Email;
                    txtHireDate.Text = employee.HireDate.ToString("yyyy-MM-dd");
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                _bal.RemoveEmployee(employeeId);
                LoadEmployees();
            }
        }

    }
}