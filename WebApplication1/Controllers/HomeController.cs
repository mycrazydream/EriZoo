using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EriZoo.DAL;
using EriZoo.ViewModels;

namespace EriZoo.Controllers
{
    public class HomeController : Controller
    {
        private ZooContext db = new ZooContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ERI Zoo's Animals";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "ERI Zoo Animal Statistics";

            IQueryable<AnimalGroup> data = from animal in db.Animals
                                                   group animal by animal.Name into animalGroup
                                                   select new AnimalGroup()
                                                   {
                                                       AnimalName = animalGroup.Key,
                                                       AnimalCount = animalGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}