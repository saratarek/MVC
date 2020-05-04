using lab2MVC.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2MVC.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(Employee employee)
        {
            ModelContext cm = new ModelContext();
            EmployeeManager em = new EmployeeManager();

            
            if (ModelState.IsValid)
            {
                em.Add(employee);
                return View("Welcome");
            }
            return View();
        }
        
    }
}