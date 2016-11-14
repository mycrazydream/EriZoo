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
    public class ZooKeepersController : Controller
    {
        private ZooContext db = new ZooContext();

        // GET: ZooKeepers
        public ActionResult Index()
        {
            return View(db.ZooKeepers.ToList());
        }

        // GET: ZooKeepers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZooKeeper zooKeeper = db.ZooKeepers.Find(id);
            if (zooKeeper == null)
            {
                return HttpNotFound();
            }
            return View(zooKeeper);
        }

        // GET: ZooKeepers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZooKeepers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,HireDate")] ZooKeeper zooKeeper)
        {
            if (ModelState.IsValid)
            {
                db.ZooKeepers.Add(zooKeeper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zooKeeper);
        }

        // GET: ZooKeepers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZooKeeper zooKeeper = db.ZooKeepers.Find(id);
            if (zooKeeper == null)
            {
                return HttpNotFound();
            }
            return View(zooKeeper);
        }

        // POST: ZooKeepers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,HireDate")] ZooKeeper zooKeeper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zooKeeper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zooKeeper);
        }

        // GET: ZooKeepers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZooKeeper zooKeeper = db.ZooKeepers.Find(id);
            if (zooKeeper == null)
            {
                return HttpNotFound();
            }
            return View(zooKeeper);
        }

        // POST: ZooKeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZooKeeper zooKeeper = db.ZooKeepers.Find(id);
            db.ZooKeepers.Remove(zooKeeper);
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
