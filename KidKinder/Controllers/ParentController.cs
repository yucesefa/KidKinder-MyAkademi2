using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{

    public class ParentController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Parents.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateParent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateParent(Parent parent)
        {
            var values = context.Parents.Add(parent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteParent(int id)
        {
            var values = context.Parents.Find(id);
            context.Parents.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateParent(int id)
        {
            var values = context.Parents.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateParent(Parent parent)
        {
            var values = context.Parents.Find(parent.ParentId);
            values.NameSurname = parent.NameSurname;
            values.PhoneNumber = parent.PhoneNumber;
            values.Address = parent.Address;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}