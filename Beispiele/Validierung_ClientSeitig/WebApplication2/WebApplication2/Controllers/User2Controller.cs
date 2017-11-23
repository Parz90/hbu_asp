using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class User2Controller : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: User2
        public ActionResult Index()
        {
            return View(db.User2.ToList());
        }

        // GET: User2/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.User2.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // GET: User2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User2/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginId,Vorname,Name")] User2 user2)
        {
            if (ModelState.IsValid)
            {
                db.User2.Add(user2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user2);
        }

        // GET: User2/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.User2.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User2/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginId,Vorname,Name")] User2 user2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user2);
        }

        // GET: User2/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User2 user2 = db.User2.Find(id);
            if (user2 == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User2 user2 = db.User2.Find(id);
            db.User2.Remove(user2);
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
