using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var result = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Username, true);
                Session["username"] = result.Username;
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(Admin admin)
        {
            if(ModelState.IsValid)
            {
                context.Admins.Add(admin);
                context.SaveChanges();
                return RedirectToAction("AdminLogin", "Login");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}