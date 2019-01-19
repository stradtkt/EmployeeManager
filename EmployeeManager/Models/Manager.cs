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
        CEO, //chief executive officer
        SVP, //senior vice president
        RD, //Regional Director
        DD, //District Director
        PM, //Plant Manager
        OM, //Operations Manager
        SM, //Sales Manager
        DM //Department Manager
    }
}
