using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serie_3___Aufgabe_2.Models;

namespace Serie_3___Aufgabe_2.Controllers
{
    public class HerausgebersController : Controller
    {
        private Serie3Aufgabe2Context db = new Serie3Aufgabe2Context();

        // GET: Herausgebers
        public ActionResult Index()
        {
            return View(db.Herausgebers.ToList());
        }

        // GET: Herausgebers/Details/5
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

        // GET: Herausgebers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herausgebers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HerausgeberId,Name,WebsiteUrl")] Herausgeber herausgeber)
        {
            if (ModelState.IsValid)
            {
                db.Herausgebers.Add(herausgeber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herausgeber);
        }

        // GET: Herausgebers/Edit/5
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

        // POST: Herausgebers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HerausgeberId,Name,WebsiteUrl")] Herausgeber herausgeber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herausgeber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herausgeber);
        }

        // GET: Herausgebers/Delete/5
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

        // POST: Herausgebers/Delete/5
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
