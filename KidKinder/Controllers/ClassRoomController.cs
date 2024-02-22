using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ClassRoomController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ClassRoomList()
        {
            var values = context.ClassRooms.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateClassRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateClassRoom(ClassRoom classRoom)
        {
            var values = context.ClassRooms.Add(classRoom);
            context.SaveChanges();
            return RedirectToAction("ClassRoomList");
        }
        public ActionResult DeleteClassRoom(int id)
        {
            var values = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ClassRoomList");
        }
        [HttpGet]
        public ActionResult UpdateClassRoom(int id)
        {
            var values = context.ClassRooms.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateClassRoom(ClassRoom classRoom)
        {
            var values = context.ClassRooms.Find(classRoom.ClassRoomId);
            values.Title = classRoom.Title;
            values.Description = classRoom.Description;
            values.TotalSeats = classRoom.TotalSeats;
            values.AgeofKids = classRoom.AgeofKids;
            values.ClassTime = classRoom.ClassTime;
            values.Price = classRoom.Price;
            values.ImageUrl = classRoom.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ClassRoomList");
        }
    }
}