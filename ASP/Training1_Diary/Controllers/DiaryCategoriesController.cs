using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training1_Diary.Models;

namespace Training1_Diary.Controllers
{
    public class DiaryCategoriesController : Controller
    {
        private Training1_DiaryContext db = new Training1_DiaryContext();

        // GET: DiaryCategories
        public ActionResult Index()
        {
            return View(db.DiaryCategories.ToList());
        }

        // GET: DiaryCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryCategory diaryCategory = db.DiaryCategories.Find(id);
            if (diaryCategory == null)
            {
                return HttpNotFound();
            }
            return View(diaryCategory);
        }

        // GET: DiaryCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiaryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiaryCategoryId,Name")] DiaryCategory diaryCategory)
        {
            if (ModelState.IsValid)
            {
                db.DiaryCategories.Add(diaryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diaryCategory);
        }

        // GET: DiaryCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryCategory diaryCategory = db.DiaryCategories.Find(id);
            if (diaryCategory == null)
            {
                return HttpNotFound();
            }
            return View(diaryCategory);
        }

        // POST: DiaryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiaryCategoryId,Name")] DiaryCategory diaryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diaryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diaryCategory);
        }

        // GET: DiaryCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryCategory diaryCategory = db.DiaryCategories.Find(id);
            if (diaryCategory == null)
            {
                return HttpNotFound();
            }
            return View(diaryCategory);
        }

        // POST: DiaryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaryCategory diaryCategory = db.DiaryCategories.Find(id);
            db.DiaryCategories.Remove(diaryCategory);
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
