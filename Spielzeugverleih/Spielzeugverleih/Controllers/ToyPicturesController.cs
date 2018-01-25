using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spielzeugverleih.Models;
using System.Drawing;
using System.IO;

namespace Spielzeugverleih.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToyPicturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToyPictures
        public ActionResult Index()
        {
            return View(db.ToyPics.ToList());
        }

        // GET: ToyPictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToyPic toyPicture = db.ToyPics.Find(id);
            if (toyPicture == null)
            {
                return HttpNotFound();
            }
            return View(toyPicture);
        }

        // GET: ToyPictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToyPictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToyPictureId,Picture,ImagePath")] ToyPic toyPicture, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    toyPicture.Picture = target.ToArray();

                    db.ToyPics.Add(toyPicture);
                    db.SaveChanges();
                    ViewBag.UploadSuccess = true;
                    return RedirectToAction("Index");
                }

            }

            return View(toyPicture);
        }

        // GET: ToyPictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToyPic toyPicture = db.ToyPics.Find(id);
            if (toyPicture == null)
            {
                return HttpNotFound();
            }
            return View(toyPicture);
        }

        // POST: ToyPictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToyPictureId,Picture,ImagePath")] ToyPic toyPicture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toyPicture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toyPicture);
        }

        // GET: ToyPictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToyPic toyPicture = db.ToyPics.Find(id);
            if (toyPicture == null)
            {
                return HttpNotFound();
            }
            return View(toyPicture);
        }

        // POST: ToyPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToyPic toyPicture = db.ToyPics.Find(id);
            db.ToyPics.Remove(toyPicture);
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
