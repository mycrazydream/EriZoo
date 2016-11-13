using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EriZoo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ERI Zoo's Animals";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to everything you wanted to know about the ERI Zoo";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
    }
}