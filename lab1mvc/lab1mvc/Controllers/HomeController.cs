using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1mvc.Controllers
{
    public class HomeController : Controller
    {
        public class Employee {
            public string Name { get; set; }
            public string Email { get; set; }
            public int Phone { get; set; }

        }

         [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegisterForm(Employee employee)
        {
            if (employee != null & employee.Email != null && employee.Name != null)
            {
                ViewBag.Name = employee.Name;
                return View("Welcome");
            }
            return View();
        }

    }
}