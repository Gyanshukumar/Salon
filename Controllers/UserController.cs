using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Salon_and_Spa.Models;

namespace Salon_and_Spa.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (var conetxt = new SalonEntities())
            {
                
                bool isvalid = conetxt.General_User.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Salon_Owner");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                }
                return View();
            }
                
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SalonEntities())
                {
                    General_User general_User = new General_User()
                    {
                        UserName = model.UserName,
                        Password = model.Password,

                    };
                    context.General_User.Add(general_User);
                    context.SaveChanges();
                }
                return RedirectToAction("login");
            }
            return View();
        }
    }
}