using MasterLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterLayout.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult getLogin(tbl_Login L)
        {
            if (ModelState.IsValid)
            {
                string uname = Request.Form["username"];
                string pasw = Request.Form["password"];
                if (DBOperations.Check(uname, pasw))
                {
                    return RedirectToAction("Index");
                }
                else
                    ViewBag.L = "Invalid details";
                
            }
            return View("Login");
        }
        public ActionResult Login()
        {
            //ViewBag.Message = "Your login page.";
            return View();
        }
    }
}