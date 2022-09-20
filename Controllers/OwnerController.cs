using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Salon_and_Spa.Models;

namespace Salon_and_Spa.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Owner model)
        {
            using (var conetxt = new SalonEntities())
            {
                bool isvalid = conetxt.Salon_Owner.Any(x => x.EmailId == model.EmailId && x.Password == model.Password);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.EmailId, false);
                    return RedirectToAction("Index", "Booking");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Owner model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SalonEntities())
                {
                    Salon_Owner salon_Owner = new Salon_Owner()
                    {
                        Name_Of_The_Salon = model.Name_Of_The_Salon,
                        EmailId = model.EmailId,
                        Location = model.Location,
                        Password = model.Password,
                        Phone_Number = model.Phone_Number,
                        Price = model.Price
                    };
                    context.Salon_Owner.Add(salon_Owner);
                    context.SaveChanges();
                }
                return RedirectToAction("login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}