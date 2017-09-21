using Serie_3___Aufgabe_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Serie_3___Aufgabe_1.Controllers
{
    public class HerausgebersController : Controller
    {
        private Serie3Aufgabe1Context db = new Serie3Aufgabe1Context();

        // GET: Herausgeber
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herausgeber herausgeber = db.Herausgebers.Find(id);
            if (herausgeber == null)
            {
                return HttpNotFound();
            }
            return View(herausgeber);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,WebsiteUrl")] Herausgeber herausgeber)
        {
            if (ModelState.IsValid)
            {
                db.Herausgebers.Add(herausgeber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herausgeber);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herausgeber herausgeber = db.Herausgebers.Find(id);
            if (herausgeber == null)
            {
                return HttpNotFound();
            }
            return View(herausgeber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name, WebsiteUrl")] Herausgeber herausgeber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herausgeber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herausgeber);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herausgeber herausgeber = db.Herausgebers.Find(id);
            if (herausgeber == null)
            {
                return HttpNotFound();
            }
            return View(herausgeber);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herausgeber herausgeber = db.Herausgebers.Find(id);
            db.Herausgebers.Remove(herausgeber);
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