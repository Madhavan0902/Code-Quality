using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementServiceModel;
using EmployeeManagementServiceDAL;

namespace EmployeeManagementServiceDAL
{
    public class EmployeeLinqDAL
    {
        public List<Employee> GetAllEmployees()
        {
            using (var db = new MyDbContext())
            {
                return db.Employee.ToList();
            }
        }
        public Employee GetAllEmployeeById(int id)
        {
            using (var db = new MyDbContext())
            {
                return db.Employee.FirstOrDefault(e => e.EmployeeId == id);
            }
        }
        public void InsertEmployee(Employee emp)
        {
            using (var db = new MyDbContext())
            {
                db.Employee.Add(emp);
                db.SaveChanges();
            }
        }
        public void UpdateEmployee(Employee emp)
        {
            using (var db = new MyDbContext())
            {
                var existing = db.Employee.Find(emp.EmployeeId);
                if (existing != null)
                {
                    existing.EmployeeName = emp.EmployeeName;
                    existing.Department = emp.Department;
                    existing.Email = emp.Email;
                    db.SaveChanges();
                }
            }
        }
        public void DeleteEmployee(int id)
        {
            using (var db = new MyDbContext())
            {
                var emp = db.Employee.Find(id);
                if (emp != null)
                {
                    db.Employee.Remove(emp);
                    db.SaveChanges();
                }
            }
        }

    }
}
