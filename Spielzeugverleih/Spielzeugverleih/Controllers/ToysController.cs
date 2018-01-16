using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spielzeugverleih.Models;

namespace Spielzeugverleih.Controllers
{
    public class ToysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Toys
        public ActionResult Index()
        {
            var toys = db.Toys.Include(t => t.Condition);
            return View(toys.ToList());
        }

        // GET: Toys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // GET: Toys/Create
        public ActionResult Create()
        {
            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description");
            ViewBag.ToyPicID = new MultiSelectList(db.ToyPictures, "ToyPicId", "Picture");
            return View();
        }

        // POST: Toys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToyId,ConditionId,ArticleNr,ToyPicId,Title,Description,Price,Active,Available")] Toy toy)
        {
            if (ModelState.IsValid)
            {
                db.Toys.Add(toy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description", toy.ConditionId);
            return View(toy);
        }

        // GET: Toys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description", toy.ConditionId);
            return View(toy);
        }

        // POST: Toys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToyId,ConditionId,ArticleNr,ToyPicId,Title,Description,Price,Active,Available")] Toy toy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description", toy.ConditionId);
            return View(toy);
        }

        // GET: Toys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toy toy = db.Toys.Find(id);
            db.Toys.Remove(toy);
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
