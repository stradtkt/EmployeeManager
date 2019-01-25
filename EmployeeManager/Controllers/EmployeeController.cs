using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeManagerContext _context;
        public EmployeeController(EmployeeManagerContext context)
        {
            _context = context;
        }
        private Employee ActiveEmployee
        {
            get
            {
                return _context.Employees.Where(e => e.Id == HttpContext.Session.GetInt32("Id")).FirstOrDefault(); 
            }
        }
        public IActionResult Profile()
        {
            if(ActiveEmployee == null)
            {
                return RedirectToAction("Home", "Login");
            }
            ViewBag.emp = ActiveEmployee;
            return View();
        }
    }
}