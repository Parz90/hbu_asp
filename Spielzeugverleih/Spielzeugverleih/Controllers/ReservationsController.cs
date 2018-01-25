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
        [Authorize]
        public ActionResult Create(int id)
        {
            List<Reservation> reservations = new List<Reservation>();
            Reservation reservation = new Reservation();
            reservation.ToyId = db.Toys.Find(id).ToyId;
            reservation.ApplicationUserId = this.User.Identity.GetUserId();

            return View(reservation);
        }
        // GET: Reservations/RejectReservations
        public ActionResult RejectReservation()
        {
            return View();
        }


        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ReservationId,ToyId,ApplicationUserId,Description,From,To,Pickup,Return")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var From = reservation.From;
                var To = reservation.To;
                var currentReservations = db.Reservations.Where(r => r.ToyId == reservation.ToyId).ToList();
                foreach (var item in currentReservations)
                {
                    if ((item.From >= reservation.From && item.From <= reservation.To) || 
                        (item.To >= reservation.From && item.To <= reservation.To) || 
                        (item.From <= reservation.From && item.To >= reservation.To))
                    {
                        return RedirectToAction("RejectReservation");
                    }
                }
                reservation.State = "Reserved";
                db.Reservations.Add(reservation);
                db.SaveChanges();

                return RedirectToAction("Index", "Toys");
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
        public ActionResult Edit([Bind(Include = "ReservationId,ToyId,ApplicationUserId,Description,From,To,State")] Reservation reservation)
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
