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

namespace EriZoo.Controllers
{
    public class FoodController : Controller
    {
        private ZooContext db = new ZooContext();

        // GET: Food
        public ActionResult Index()
        {
            var foods = db.Foods.Include(f => f.Animal).Include(f => f.Vendor);
            return View(foods.ToList());
        }

        // GET: Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name");
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "Name");
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Calories,VendorID,AnimalID")] Food food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Foods.Add(food);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException d)
            {
                ModelState.AddModelError(d.ToString(), "Unable to create Food record. If the problem persists see your local technician.");
            }

            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name", food.AnimalID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "Name", food.VendorID);
            return View(food);
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name", food.AnimalID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "Name", food.VendorID);
            return View(food);
        }

        // POST: Food/Edit/5
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

            var foodToUpdate = db.Foods.Find(id);

            if (TryUpdateModel(foodToUpdate, "", new string[] { "Name", "Calories", "VendorID", "AnimalID" }))
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

            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name", foodToUpdate.AnimalID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "Name", foodToUpdate.VendorID);

            return View(foodToUpdate);
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
            db.SaveChanges();
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
