using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class SubscribeController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.MailSubscribes.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSubscribe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSubscribe(MailSubscribe mailSubscribe)
        {
            var values = context.MailSubscribes.Add(mailSubscribe);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSubscribe(int id)
        {
            var values = context.MailSubscribes.Find(id);
            context.MailSubscribes.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSubscribe(int id)
        {
            var values = context.MailSubscribes.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSubscribe(MailSubscribe mailSubscribe)
        {
            var values = context.MailSubscribes.Find(mailSubscribe.MailSubscribeId);
            values.NameSurname = mailSubscribe.NameSurname;
            values.Email = mailSubscribe.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}