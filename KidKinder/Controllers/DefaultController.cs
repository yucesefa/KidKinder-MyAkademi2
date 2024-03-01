using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class DefaultController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAboutList()
        {
            var values = context.AboutLists.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialClassRooms()
        {
            var valeus = context.ClassRooms.OrderByDescending(x=>x.ClassRoomId).Take(3).ToList();
            return PartialView(valeus);
        }
        public PartialViewResult PartialTeacher()
        {
            var values = context.Teachers.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            ViewBag.phone = context.Communications.Select(x => x.Phone).FirstOrDefault();
            ViewBag.address = context.Communications.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Communications.Select(x => x.Email).FirstOrDefault();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult PartialSubscribe()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialSubscribe(MailSubscribe mailSubscribe)
        {
            if(ModelState.IsValid)
            {
                context.MailSubscribes.Add(mailSubscribe);
                context.SaveChanges();
            }
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}