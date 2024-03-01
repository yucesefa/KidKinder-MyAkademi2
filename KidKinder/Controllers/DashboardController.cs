using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            //Branşı Dil eğitimi olan öğretmen sayısı
            ViewBag.DilEgitimCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.BranchName == "Dil Öğretmeni").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.AvgPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");
            ViewBag.Testimonial = context.Testimonials.Count();
            ViewBag.Service = context.Services.Count();
            ViewBag.BookASeat = context.BookASeats.Count();
            ViewBag.Teacher = context.Teachers.Count();
            ViewBag.Subscribe = context.MailSubscribes.Count();
            ViewBag.ClassRoom = context.ClassRooms.Count();
            ViewBag.Branch = context.Branches.Count();
            ViewBag.Contact = context.Contacts.Count();
            var values = context.Teachers.ToList();
            return View(values);
        }
    }
}