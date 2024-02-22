using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace KidKinder.Controllers
{
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult ContactAddressPartial()
        {
            ViewBag.description = context.Communications.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Communications.Select(x => x.Phone).FirstOrDefault();
            ViewBag.address = context.Communications.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Communications.Select(x => x.Email).FirstOrDefault();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult ContactProcessPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ContactProcessPartial(Contact contact)
        {
            if(ModelState.IsValid)
            {
                contact.IsRead = false;
                contact.SendDate = DateTime.Now;
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
            return PartialView();
        }
    }
}