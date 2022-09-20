using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon_and_Spa.Models;

using Salon_and_Spa.Models;
namespace Salon_and_Spa.Controllers
{
    [Authorize]
    public class Salon_OwnerController : Controller
    {
        private SalonEntities db = new SalonEntities();
        private readonly object userid;

        // GET: Salon_Owner
        public ActionResult Index()
        {
            
            TempData.Keep("UserId");
            return View(db.Salon_Owner.ToList());
        }

        // GET: Salon_Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon_Owner salon_Owner = db.Salon_Owner.Find(id);
            if (salon_Owner == null)
            {
                return HttpNotFound();
            }
            return View(salon_Owner);
        }

   /*     // GET: Salon_Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salon_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CorporateId,Name_Of_The_Salon,EmailId,Location,Password,Phone_Number,Price")] Salon_Owner salon_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Salon_Owner.Add(salon_Owner);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(salon_Owner);
        }
        */
        // GET: Salon_Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon_Owner salon_Owner = db.Salon_Owner.Find(id);
            if (salon_Owner == null)
            {
                return HttpNotFound();
            }
            return View(salon_Owner);
        }

        // POST: Salon_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CorporateId,Name_Of_The_Salon,EmailId,Location,Password,Phone_Number,Price")] Salon_Owner salon_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salon_Owner);
        }

        // GET: Salon_Owner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon_Owner salon_Owner = db.Salon_Owner.Find(id);
            if (salon_Owner == null)
            {
                return HttpNotFound();
            }
            return View(salon_Owner);
        }

        // POST: Salon_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salon_Owner salon_Owner = db.Salon_Owner.Find(id);
            db.Salon_Owner.Remove(salon_Owner);
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


        public  ActionResult  Booking(int id)
        {
            General_User genral_user = new General_User(); 
            TempData["CorporateId"] = id;
            return RedirectToAction("Create", "Books");
        }
    }
}
