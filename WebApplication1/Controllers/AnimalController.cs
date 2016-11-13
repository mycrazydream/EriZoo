using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EriZoo.DAL;
using EriZoo.Models;
using X.PagedList;

namespace EriZoo.Controllers
{
    public class AnimalController : Controller
    {
        private ZooContext db = new ZooContext();

        // GET: Animal
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ADateSortParm   = sortOrder == "ADate"      ? "ADate_desc"      : "ADate";
            ViewBag.BDateSortParm   = sortOrder == "BDate"      ? "BDate_desc"      : "BDate";
            ViewBag.GroupSortParm   = sortOrder == "Group"      ? "Group_desc"      : "Group";
            ViewBag.SubGroupParm    = sortOrder == "SubGroup"   ? "SubGroup_desc"   : "SubGroup";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var animals = from a in db.Animals
                           select a;
            if (!string.IsNullOrEmpty(searchString))
            {
                animals = animals.Where(a => a.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    animals = animals.OrderByDescending(a => a.Name);
                    break;
                case "ADate":
                    animals = animals.OrderBy(a => a.AcquisitionDate);
                    break;
                case "ADate_desc":
                    animals = animals.OrderByDescending(a => a.AcquisitionDate);
                    break;
                case "BDate":
                    animals = animals.OrderBy(a => a.BirthDate);
                    break;
                case "BDate_desc":
                    animals = animals.OrderByDescending(a => a.BirthDate);
                    break;
                case "Group":
                    animals = animals.OrderBy(a => a.Group);
                    break;
                case "Group_desc":
                    animals = animals.OrderByDescending(a => a.Group);
                    break;
                case "SubGroup":
                    animals = animals.OrderBy(a => a.SubGroup);
                    break;
                case "SubGroup_desc":
                    animals = animals.OrderByDescending(a => a.SubGroup);
                    break;
                default:
                    animals = animals.OrderBy(a => a.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(animals.ToPagedList(pageNumber, pageSize));
        }

        // GET: Animal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Group,SubGroup,AcquisitionDate,BirthDate")] Animal animal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Animals.Add(animal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException d)
            {
                ModelState.AddModelError(d.ToString(), "Unable to create Animal record. If the problem persists see your local technician.");
            }

            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        // TODO:  If only individual fields need to be updated in the database,
        // set the entity to Unchanged and set individual fields to Modified
        [HttpPost, ActionName("Edit")] //renamed the method EditPost to avoid conflict with other Edit action
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animalToUpdate = db.Animals.Find(id);

            if (TryUpdateModel(animalToUpdate, "", new string[] { "Name", "Group", "SubGroup", "AcquisitionDate", "BirthDate"}))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes to animal. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(animalToUpdate);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Animal animal = db.Animals.Find(id);
                db.Animals.Remove(animal);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
