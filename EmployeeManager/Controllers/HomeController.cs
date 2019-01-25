using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace EmployeeManager.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeManagerContext _context;
        public HomeController(EmployeeManagerContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("register-employee")]
        public IActionResult RegisterEmployee(Employee emp)
        {
            Employee CheckEmail = _context.Employees
                .Where(e => e.Email == emp.Email)
                .SingleOrDefault();
            if(CheckEmail != null)
            {
                ViewBag.errors = "That email already exists";
                return RedirectToAction("Register");
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<Employee> Hasher = new PasswordHasher<Employee>();
                Employee newEmp = new Employee
                {
                    Name = emp.Name,
                    Email = emp.Email,
                    Password = Hasher.HashPassword(emp, emp.Password),
                    Active = true,
                    Age = emp.Age,
                    Title = emp.Title,
                    Department = emp.Department,
                    Salary = emp.Salary
                };
                _context.Add(newEmp);
                _context.SaveChanges();
                ViewBag.success = "Successfully registered";
                return RedirectToAction("Login");
            }
            else
            {
                return View("Register");
            }
        }
        [HttpPost("login-user")]
        public IActionResult LoginEmployee(Employee emp)
        {
            Employee CheckEmail = _context.Employees
                .SingleOrDefault(e => e.Email == emp.Email);
            if (CheckEmail != null)
            {
                var Hasher = new PasswordHasher<Employee>();
                if (0 != Hasher.VerifyHashedPassword(CheckEmail, CheckEmail.Password, emp.Password))
                {
                    HttpContext.Session.SetInt32("user_id", CheckEmail.Id);
                    HttpContext.Session.SetString("first_name", CheckEmail.Name);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.errors = "Incorrect Password";
                    return View("Register");
                }
            }
            else
            {
                ViewBag.errors = "Email not registered";
                return View("Register");
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

