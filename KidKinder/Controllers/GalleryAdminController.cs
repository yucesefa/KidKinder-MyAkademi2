using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class GalleryAdminController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Galleries.ToList();
            return View(values);
        }
        public ActionResult ActiveGalleryAdmin(int id)
        {
            var values = context.Galleries.Find(id);
            values.StatusImage = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PassiveGalleryAdmin(int id)
        {
            var values = context.Galleries.Find(id);
            values.StatusImage = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateGalleryAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGalleryAdmin(Gallery gallery)
        {
            var values = context.Galleries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}