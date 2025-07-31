using EmployeeManagementServiceDAL;
using EmployeeManagementServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementServiceBAL
{
    public class EmployeeLinqBAL
    {
        private readonly EmployeeLinqDAL _employeeDAL;
        public EmployeeLinqBAL()
        {
            _employeeDAL = new EmployeeLinqDAL();
        }
        public void AddEmployee(Employee emp)
        {
            _employeeDAL.InsertEmployee(emp);
        }
        public void ModifyEmployee(Employee emp)
        {
            _employeeDAL.UpdateEmployee(emp);
        }
        public void RemoveEmployee(int id)
        {
            _employeeDAL.DeleteEmployee(id);
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.GetAllEmployees();
        }
        public Employee GetEmployee(int id)
        {
            return _employeeDAL.GetAllEmployeeById(id);
        }

    }
}
