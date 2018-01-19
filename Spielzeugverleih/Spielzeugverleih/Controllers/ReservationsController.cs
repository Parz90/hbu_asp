using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spielzeugverleih.Models;
using Microsoft.AspNet.Identity;

namespace Spielzeugverleih.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.ApplicationUser).Include(r => r.Toy);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        /*public ActionResult Create()
        {
            ViewBag.Username = this.User.Identity.GetUserName();
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.ToyId = new SelectList(db.Toys, "ToyId", "ArticleNr");
            return View();
        }
        */

        // GET: Reservations/Create
        public ActionResult Create(int id)
        {
            List<Reservation> reservations = new List<Reservation>();
            reservations = db.Reservations.ToList();
            foreach (var res in reservations)
            {
                if (res.ToyId == id)
                {
                    return RedirectToAction("Index", "Toys");
                }

            }
            Reservation reservation = new Reservation();
            reservation.ToyId = db.Toys.Find(id).ToyId;
            reservation.ApplicationUserId = this.User.Identity.GetUserId();

            return View(reservation);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,ToyId,ApplicationUserId,Description,From,To,Pickup,Return")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var From = reservation.From;
                var toylist = db.Reservations.Where(r => r.ToyId == reservation.ToyId).ToList();
                var reservedToy = toylist.Where(t => t.From > reservation.From && t.To < reservation.To);
                /*if (reservedToy != null && reservedToy.Any())
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                }*/
                db.Reservations.Add(reservation);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", reservation.ApplicationUserId);
            ViewBag.ToyId = new SelectList(db.Toys, "ToyId", "ArticleNr", reservation.ToyId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", reservation.ApplicationUserId);
            ViewBag.ToyId = new SelectList(db.Toys, "ToyId", "ArticleNr", reservation.ToyId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ReservationId,ToyId,ApplicationUserId,Description,From,To,Pickup,Return")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", reservation.ApplicationUserId);
            ViewBag.ToyId = new SelectList(db.Toys, "ToyId", "ArticleNr", reservation.ToyId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
