using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon_and_Spa;
using Salon_and_Spa.Models;

namespace Salon_and_Spa.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private SalonEntities db = new SalonEntities();

        // GET: Booking
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.General_User).Include(b => b.Salon_Owner);
            return View(books.ToList());
        }

        public ActionResult UpcomingBooking()
        {
            var books = db.Books.Include(b => b.General_User).Include(b => b.Salon_Owner);
            return View(books.ToList());
        }
        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.General_User, "UserId", "UserName");
            ViewBag.CorporateId = new SelectList(db.Salon_Owner, "CorporateId", "Name_Of_The_Salon");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CorporateId,Date,Time")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.General_User, "UserId", "UserName", book.UserId);
            ViewBag.CorporateId = new SelectList(db.Salon_Owner, "CorporateId", "Name_Of_The_Salon", book.CorporateId);
            return View(book);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            TempData["UserId"] = book.UserId;
            TempData["CorporateId"] = book.CorporateId;
            return View(book);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,CorporateId,Date,Time")] Book book)
        {
            SalonEntities salonEntities = new SalonEntities();
            foreach(var item in salonEntities.Books)
            {
                if(book.Id== item.Id)
                {
                    book.UserId = item.UserId;
                    book.CorporateId = item.CorporateId;
                }
            }
            
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","booking");
            }
            ViewBag.UserId = new SelectList(db.General_User, "UserId", "UserName", book.UserId);
            ViewBag.CorporateId = new SelectList(db.Salon_Owner, "CorporateId", "Name_Of_The_Salon", book.CorporateId);
            return View(book);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult History()
        {
            SalonEntities salonEntities = new SalonEntities();

            return View(salonEntities.Books.ToList());
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
