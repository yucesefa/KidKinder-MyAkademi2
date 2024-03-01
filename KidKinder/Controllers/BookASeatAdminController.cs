using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class BookASeatAdminController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateBookASeatAdmin()
        {
            ViewBag.ClassRoom = new SelectList(context.ClassRooms.ToList(), "ClassRoomId", "Title");
            var classRoom = context.ClassRooms.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateBookASeatAdmin(BookASeat bookASeat)
        {
            if (ModelState.IsValid)
            {
                context.BookASeats.Add(bookASeat);
                context.SaveChanges();
                return RedirectToAction("Index", "BookASeatAdmin");
            }
            return View();
        }
        public ActionResult DeleteBookASeatAdmin(int id)
        {
            var values = context.BookASeats.Find(id);
            context.BookASeats.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBookASeatAdmin(int id)
        {
            ViewBag.ClassRoom = new SelectList(context.ClassRooms.ToList(), "ClassRoomId", "Title");
            var classRoom = context.ClassRooms.ToList();
            var values = context.BookASeats.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateBookASeatAdmin(BookASeat bookASeat)
        {
            var values = context.BookASeats.Find(bookASeat.BookASeatId);
            values.NameSurname = bookASeat.NameSurname;
            values.Email = bookASeat.Email;
            values.PhoneNumber = bookASeat.PhoneNumber;
            values.ClassRoomId = bookASeat.ClassRoomId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}