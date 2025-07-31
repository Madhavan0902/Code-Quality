using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeeManagementServiceModel;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace EmployeeManagementServiceDAL
{
    public class EmployeeDAL
    {
        string Connstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using(MySqlConnection conn = new MySqlConnection(Connstr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Employee",conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //int id = Convert.ToInt32(reader["EmployeeId"]);
                    //string name = Convert.ToString(reader["EmployeeName"]);
                    //string email = reader["email"].ToString();

                    employees.Add(new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        EmployeeName = (string)reader["EmployeeName"],
                        Email = (string)reader["Email"]
                    });
                }
                return employees;
            }
        }
    }
}
