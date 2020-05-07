using lab2MVC.Managers;
using lab2MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            EmployeeViewModel viewmodel = new EmployeeViewModel
            {
                Employees = cx.Employees.ToList(),
                Employee = new Employee()
            };
            return View(viewmodel);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            //EmployeeViewModel employeeviewmodel = new EmployeeViewModel
            //{
            //    Departments = cx.Departments.ToList()
            //};
            return View("EmployeeForm");
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            ModelContext cm = new ModelContext();
            EmployeeManager em = new EmployeeManager();
            if (ModelState.IsValid)
            {
                cx.Employees.Add(employee);
                cx.SaveChanges();
                TempData["Message"] = "Employee Added Successfully";
                
                return RedirectToAction(nameof(Index));
            }
            //EmployeeViewModel employeeviewmodel = new EmployeeViewModel
            //{
            //    Departments = cx.Departments.ToList()
            //};
            ViewBag.Action = "Add";
            return View("EmployeeForm", employee);
        }
        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {

            if (ModelState.IsValid)
            {
                cx.Employees.Add(employee);
                cx.SaveChanges();
                TempData["Message"] = "Employee added successfuly";
                return PartialView("_EmployeePartial", employee);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            Employee employee = cx.Employees.Find(id);
            if(employee != null)
            {
                ViewBag.Action = "Edit";
                //EmployeeViewModel employeeviewmodel = new EmployeeViewModel
                //{
                //    Departments = cx.Departments.ToList(),
                //    Employee = employee
                //};
                return View("EmployeeForm", employee);
            }
            
            return HttpNotFound("Employee not Found");
        }
        [HttpPost]
        public ActionResult Edit (Employee employee)
        {
            if (ModelState.IsValid)
            {
                cx.Employees.Attach(employee);
                cx.Entry(employee).State = EntityState.Modified;
                cx.SaveChanges();
                return RedirectToAction(nameof(Index));         
            }
            ViewBag.Action = "Edit";
            //EmployeeViewModel employeeviewmodel = new EmployeeViewModel
            //{
            //    Departments = cx.Departments.ToList(),
            //    Employee = employee
            //};
            return View("EmployeeForm", employee);


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ModelContext cm = new ModelContext();
            Employee employee = cm.Employees.Find(id);
            if(employee != null)
            {
                cm.Employees.Remove(employee);
                cm.SaveChanges();
                return Json(true);
            }
            return HttpNotFound("employee not deleted");
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