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

        public ActionResult NoCond()
        {
            return View();
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            if (db.Conditions.Count() == 0)
            {
                return RedirectToAction("NoCond");
            }
            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description");
            ViewBag.PictureList = new List<ToyPic>(db.ToyPics.ToList());
            ViewBag.MultiSelectPictureList = new MultiSelectList(db.ToyPics.ToList(), "ToyPicId", "Picture");

            return View();
        }

        // POST: Toys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Toy toy)
        {
            if (ModelState.IsValid)
            {

                foreach (HttpPostedFileBase file in toy.files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);

                            var toyPic = new ToyPic()
                            {
                                Toy = toy,
                                Picture = ms.ToArray()
                            };

                            if (toy.ToyPicList == null)
                                toy.ToyPicList = new List<ToyPic>();
                            toy.ToyPicList.Add(toyPic);
                        }
                    }

                }

                db.Toys.Add(toy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description", toy.ConditionId);

            return View(toy);
        }

        // GET: Toys/Edit/5

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Toy toy)
        {
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in toy.files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);

                            var toyPic = new ToyPic()
                            {
                                Toy = toy,
                                ToyId = toy.ToyId,
                                Picture = ms.ToArray()
                            };

                            if (toy.ToyPicList == null)
                            {
                                toy.ToyPicList = new List<ToyPic>();
                            }
                            db.ToyPics.Add(toyPic);
                        }
                    }

                }

                ////Not working at the moment!!!
                //foreach (var item in toy.ToyPicList)
                //{
                //    if (item.Delete == true)
                //    {
                //        db.ToyPics.Remove(item);
                //    }
                //}

                db.Entry(toy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description", toy.ConditionId);
            return View(toy);
        }

        // GET: Toys/Delete/5
        [Authorize(Roles = "Admin")]
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
            var reservations = db.Reservations.ToList();
            foreach (var res in reservations)
            {
                if (res.ToyId == id)
                {
                    return RedirectToAction("RejectDelete");
                }

            }
            return View(toy);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Toy toy = db.Toys.Find(id);
            db.Toys.Remove(toy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Toys/RejectDelete
        public ActionResult RejectDelete()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DeleteToyPic(int id, int toypicid)
        {
            try
            {
                var toyPic = db.ToyPics.Single(x => x.ToyPicId == toypicid);
                db.ToyPics.Remove(toyPic);
                db.SaveChanges();
                var toy = db.Toys.Include(y=>y.ToyPicList).Single(x => x.ToyId == id);

                ViewBag.ConditionId = new SelectList(db.Conditions, "ConditionId", "Description", toy.ConditionId);

                return View("Edit", toy);
            }
            catch(Exception exc)
            {
                Console.WriteLine("An error occurred: '{0}'", exc);
                throw;
            }
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
