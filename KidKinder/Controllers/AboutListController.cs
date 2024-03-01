using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AboutListController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.AboutLists.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAboutList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAboutList(AboutList aboutlist)
        {
            var values = context.AboutLists.Add(aboutlist);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAboutList(int id)
        {
            var values = context.AboutLists.Find(id);
            context.AboutLists.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAboutList(int id)
        {
            var values = context.AboutLists.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAboutList(AboutList aboutlist)
        {
            var values = context.AboutLists.Find(aboutlist.AboutListId);
            values.Description = aboutlist.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}