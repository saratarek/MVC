using lab2MVC.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2MVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager em = new EmployeeManager();

        ModelContext cx = new ModelContext();

        [HttpGet]
        public ViewResult Index()
        {
            return View(cx.Employees.ToList());
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            ModelContext cm = new ModelContext();
            EmployeeManager em = new EmployeeManager();
            if (ModelState.IsValid)
            {
                em.Add(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ModelContext cm = new ModelContext();
                em.Delete(id);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
           Employee employee=em.GetById(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(employee);
        }
        
      
        [ChildActionOnly]
        public PartialViewResult EmployeePartial(Employee employee)
        {
            return PartialView("_EmployeePartial", employee);
        }

    }
}