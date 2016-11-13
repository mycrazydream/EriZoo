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
    public class VendorController : Controller
    {
        private ZooContext db = new ZooContext();

        // GET: Vendor
        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Address,Address2")] Vendor vendor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Vendors.Add(vendor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException d)
            {
                ModelState.AddModelError(d.ToString(), "Unable to create Vendor record. If the problem persists see your local technician.");
            }
            
            return View(vendor);
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        // TODO:  If only individual fields need to be updated in the database,
        // set the entity to Unchanged and set individual fields to Modified
        //renamed the method EditPost to avoid conflict with other Edit action
        [HttpPost, ActionName("Edit")] //renamed the method EditPost to avoid conflict with other Edit action
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vendorToUpdate = db.Vendors.Find(id);

            if (TryUpdateModel(vendorToUpdate, "", new string[] { "Name", "Phone", "Address", "Address2" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes to vendor. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(vendorToUpdate);
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
