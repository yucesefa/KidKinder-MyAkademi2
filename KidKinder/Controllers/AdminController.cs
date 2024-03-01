using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Admins.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {
            var values = context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var values = context.Admins.Find(id);
            context.Admins.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = context.Admins.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var values = context.Admins.Find(admin.AdminId);
            values.Username = admin.Username;
            values.Password = admin.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}