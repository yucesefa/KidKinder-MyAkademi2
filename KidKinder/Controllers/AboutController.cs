using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            var values = context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.Abouts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var values = context.Abouts.Find(about.AboutId);
            values.Title = about.Title;
            values.Header = about.Header;
            values.Description = about.Description;
            values.AboutBigImageUrl = about.AboutBigImageUrl;
            values.AboutSmallImageUrl = about.AboutSmallImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}