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
            //try
            //{
            //    throw new Exception("CustomError");
            //}
            //catch (Exception)
            //{
            //    return View("Error");
            //}
            return View();
        
         }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }


    }
}