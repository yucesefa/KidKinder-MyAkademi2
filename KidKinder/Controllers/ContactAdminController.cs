using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ContactAdminController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Contacts.OrderByDescending(x => x.ContactId).ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = context.Contacts.Find(id);
            return View(value);
        }
        public ActionResult MarkAsRead(int id)
        {
            var message = context.Contacts.Find(id);
            message.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = context.Contacts.Find(id);
            context.Contacts.Remove(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}