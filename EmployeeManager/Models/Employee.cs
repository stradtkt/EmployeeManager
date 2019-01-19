using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public decimal Salary { get; set; }
        public List<ManagersEmployees> Managers { get; set; }
        public Employee()
        {
            Managers = new List<ManagersEmployees>();
        }
    }
}
