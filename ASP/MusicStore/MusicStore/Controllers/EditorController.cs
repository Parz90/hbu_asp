using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class EditorController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET: Editors
        public ActionResult Index()
        {

            return View(db.Editors.ToList());

        }

        // GET: Editors/Details/6
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Editor editor = db.Editors.Find(id);

            if (editor == null)
            {
                return HttpNotFound();
            }

            return View(editor);
        }

        // GET: Editors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Editors.Add(editor);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editor);
        }

        // GET: Editors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }

            return View(editor);
        }

        // POST: Editors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editor);
        }

        // GET: Editors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            return View(editor);
        }

        // POST: Editors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Editors.Remove(db.Editors.Find(id));

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