using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public ManagerRanking ManagerRanking { get; set; }
        public List<ManagersEmployees> Staff { get; set; }
        public decimal Salary { get; set; }
        public Manager()
        {
            Staff = new List<ManagersEmployees>();
        }
    }
    public enum ManagerRanking
    {
        CEO = 1, //chief executive officer
        SVP = 2, //senior vice president
        RD = 3, //Regional Director
        DD = 4, //District Director
        PM = 5, //Plant Manager
        OM = 6, //Operations Manager
        SM = 7, //Sales Manager
        DM = 8 //Department Manager
    }
}
