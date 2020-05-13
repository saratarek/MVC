using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using labmvc.Models;

namespace labmvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //Any User
        [AllowAnonymous] // anyone see index
        public ActionResult Index()
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser adminUser = userManager.FindByEmail("admin@gmail.com");
            ApplicationUser managerUser = userManager.FindByEmail("manager@gmail.com");
            ApplicationUser clientUser = userManager.FindByEmail("client@gmail.com");

            //take every user and add it on specific role 
            userManager.AddToRole(adminUser.Id, "Admin");
            userManager.AddToRole(managerUser.Id, "Manager");
            userManager.AddToRole(clientUser.Id, "Client");
            return View();
        }

        //Authenticated
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Authenticated --> 3amel login
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Admin
        [Authorize (Roles ="Admin")]
        public ActionResult ForAdmin()
        {

            return View();
        }
        //Admin & Manager
        [Authorize (Roles ="Admin,Manager")]
        public ActionResult ForManager()
        {

            return View();
        }
        //Admin & Client
        [Authorize (Roles ="Admin,Client")]
        public ActionResult ForClient()
        {

            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                RoleManager<IdentityRole> roleManager =
                    new RoleManager<IdentityRole>
                    (new RoleStore<IdentityRole>(new ApplicationDbContext()));
                roleManager.Create(role);
               return RedirectToAction("Index");
            }
            return View();
        }
    }
}