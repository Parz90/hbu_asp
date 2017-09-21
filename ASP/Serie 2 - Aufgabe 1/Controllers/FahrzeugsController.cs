using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serie_2___Aufgabe_1.Models;

namespace Serie_2___Aufgabe_1.Controllers
{
    public class FahrzeugsController : Controller
    {
        private Serie2Aufgabe1Context db = new Serie2Aufgabe1Context();

        // GET: Fahrzeugs
        public ActionResult Index()
        {
            return View(db.Fahrzeugs.ToList());
        }

        // GET: Fahrzeugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fahrzeug fahrzeug = db.Fahrzeugs.Find(id);
            if (fahrzeug == null)
            {
                return HttpNotFound();
            }
            return View(fahrzeug);
        }

        // GET: Fahrzeugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fahrzeugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FahrzeugId,Hubraum,PS,FarbId,HerstellerId")] Fahrzeug fahrzeug)
        {
            if (ModelState.IsValid)
            {
                db.Fahrzeugs.Add(fahrzeug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fahrzeug);
        }

        // GET: Fahrzeugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fahrzeug fahrzeug = db.Fahrzeugs.Find(id);
            if (fahrzeug == null)
            {
                return HttpNotFound();
            }
            return View(fahrzeug);
        }

        // POST: Fahrzeugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FahrzeugId,Hubraum,PS,FarbId,HerstellerId")] Fahrzeug fahrzeug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fahrzeug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fahrzeug);
        }

        // GET: Fahrzeugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fahrzeug fahrzeug = db.Fahrzeugs.Find(id);
            if (fahrzeug == null)
            {
                return HttpNotFound();
            }
            return View(fahrzeug);
        }

        // POST: Fahrzeugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fahrzeug fahrzeug = db.Fahrzeugs.Find(id);
            db.Fahrzeugs.Remove(fahrzeug);
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
