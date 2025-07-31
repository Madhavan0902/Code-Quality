using EmployeeManagementServiceDAL;
using EmployeeManagementServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementServiceBAL
{
    public class EmployeeBAL
    {
        EmployeeDAL EmployeeDAL = new EmployeeDAL();
        public List<Employee> GetAllEmployees() => EmployeeDAL.GetAllEmployees();

    }
}
