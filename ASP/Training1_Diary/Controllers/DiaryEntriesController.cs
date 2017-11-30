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
    public class DiaryEntriesController : Controller
    {
        private Training1_DiaryContext db = new Training1_DiaryContext();

        // GET: DiaryEntries
        public ActionResult Index()
        {
            var diaryEntries = db.DiaryEntries.Include(d => d.DiaryCategory);
            return View(diaryEntries.ToList());
        }

        // GET: DiaryEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Create
        public ActionResult Create()
        {
            ViewBag.DiaryCategoryId = new SelectList(db.DiaryCategories, "DiaryCategoryId", "Name");
            return View();
        }

        // POST: DiaryEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiaryEntryId,DiaryCategoryId,Title,Date,Entry1,Entry2,Entry3")] DiaryEntry diaryEntry)
        {
            if (ModelState.IsValid)
            {
                db.DiaryEntries.Add(diaryEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiaryCategoryId = new SelectList(db.DiaryCategories, "DiaryCategoryId", "Name", diaryEntry.DiaryCategoryId);
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiaryCategoryId = new SelectList(db.DiaryCategories, "DiaryCategoryId", "Name", diaryEntry.DiaryCategoryId);
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiaryEntryId,DiaryCategoryId,Title,Date,Entry1,Entry2,Entry3")] DiaryEntry diaryEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diaryEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiaryCategoryId = new SelectList(db.DiaryCategories, "DiaryCategoryId", "Name", diaryEntry.DiaryCategoryId);
            return View(diaryEntry);
        }

        // GET: DiaryEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
            db.DiaryEntries.Remove(diaryEntry);
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

        public ActionResult QuickSearch(string term)
        {
            var kategory = GetDiaryKategory(term).Select(a => new { value = a.Name });
            return Json(kategory, JsonRequestBehavior.AllowGet);    

        }

        private List<DiaryCategory> GetDiaryKategory(string searchString)
        {
            return db.DiaryCategories.Where(a => a.Name.Contains(searchString)).ToList();
        }
    }
}
