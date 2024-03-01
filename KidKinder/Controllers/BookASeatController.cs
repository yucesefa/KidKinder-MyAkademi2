using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class BookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult BookASeat()
        {
            return View();
        }
        public ActionResult BookASeatList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BookASeatProcess()
        {
            ViewBag.ClassRoom = new SelectList(context.ClassRooms.ToList(), "ClassRoomId", "Title");
            var classRoom = context.ClassRooms.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult BookASeatProcess(BookASeat bookASeat)
        {
            if (ModelState.IsValid)
            {
                context.BookASeats.Add(bookASeat);
                context.SaveChanges();
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}