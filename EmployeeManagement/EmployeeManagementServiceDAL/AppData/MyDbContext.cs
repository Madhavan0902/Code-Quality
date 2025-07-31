using EmployeeManagementServiceModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyDbContext : DbContext

{
    public MyDbContext() :base("name=DefaultConnection") { }
    public DbSet<Employee> Employee { get; set; }
}

