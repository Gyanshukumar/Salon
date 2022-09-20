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
    public class BooksController : Controller
    {
        private SalonEntities db = new SalonEntities();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.General_User).Include(b => b.Salon_Owner);
            return View(books.ToList());
        }

        // GET: Books/Details/5
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

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.UserId =TempData["UserId"] ;
            TempData.Keep("UserId");
            ViewBag.CorporateId = TempData["CorporateId"];
            TempData.Keep("COrporateId");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CorporateId,Date,Time")] Book book)
        {
            SalonEntities salonEntities = new SalonEntities();
            foreach(var item in salonEntities.General_User)
            {
                if(item.UserName==User.Identity.Name)
                {
                    ViewBag.UserId = item.UserId;
                }
            }
            ViewBag.CorporateId = TempData["CorporateId"];
            TempData.Keep("COrporateId");
            book.UserId = ViewBag.UserId;
            book.CorporateId = ViewBag.CorporateId;

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index","salon_owner");
            }

            ViewBag.UserId = TempData["UserId"];
            TempData.Keep("UserId");
            ViewBag.CorporateId = TempData["CorporateId"];
            TempData.Keep("COrporateId");
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id )
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
            SalonEntities salonEntities = new SalonEntities();
         foreach(var item in salonEntities.General_User)
            {
                if (item.UserName == User.Identity.Name)
                {
                    ViewBag.UserId = item.UserId;
                }
            }
         ViewBag.CorporateId = new SelectList(db.Salon_Owner, "CorporateId", "Name_Of_The_Salon", book.CorporateId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,CorporateId,Date,Time")] Book book)
        {
            SalonEntities salonEntities = new SalonEntities();
            foreach (var item in salonEntities.General_User)
            {
                if (item.UserName == User.Identity.Name)
                {
                    ViewBag.UserId = item.UserId;
                }
            }
            book.UserId = ViewBag.UserId;
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index","salon_owner");
            }
            
            ViewBag.CorporateId = new SelectList(db.Salon_Owner, "CorporateId", "Name_Of_The_Salon", book.CorporateId);
            return View(book);
        }

        // GET: Books/Delete/5
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("History", "Books");
        }

        public  ActionResult History()
        {
            SalonEntities salonEntities = new SalonEntities();

            return View(salonEntities.Books.ToList());
        }

        public ActionResult UpcomingBooking()
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
