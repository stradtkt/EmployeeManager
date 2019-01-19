using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class EmployeeManagerContext : DbContext
    {
        public EmployeeManagerContext(DbContextOptions<EmployeeManagerContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagersEmployees> Managers_has_Employees { get; set; }
    }
}
