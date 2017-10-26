﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serie_3___Aufgabe_2;
using Serie_3___Aufgabe_2.Models;

namespace Serie_3___Aufgabe_2.Controllers
{
    public class SprachesController : Controller
    {
        private Serie3Aufgabe2Context db = new Serie3Aufgabe2Context();

        // GET: Spraches
        public ActionResult Index()
        {
            return View(db.Spraches.ToList());
        }

        // GET: Spraches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprache sprache = db.Spraches.Find(id);
            if (sprache == null)
            {
                return HttpNotFound();
            }
            return View(sprache);
        }

        // GET: Spraches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spraches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpracheId,Name")] Sprache sprache)
        {
            if (ModelState.IsValid)
            {
                db.Spraches.Add(sprache);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sprache);
        }

        // GET: Spraches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprache sprache = db.Spraches.Find(id);
            if (sprache == null)
            {
                return HttpNotFound();
            }
            return View(sprache);
        }

        // POST: Spraches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpracheId,Name")] Sprache sprache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sprache);
        }

        // GET: Spraches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprache sprache = db.Spraches.Find(id);
            if (sprache == null)
            {
                return HttpNotFound();
            }
            return View(sprache);
        }

        // POST: Spraches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sprache sprache = db.Spraches.Find(id);
            db.Spraches.Remove(sprache);
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
