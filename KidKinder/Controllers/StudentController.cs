using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class StudentController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            var values = context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStudent(int id)
        {
            var values = context.Students.Find(id);
            context.Students.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var values = context.Students.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var values = context.Students.Find(student.StudentId);
            values.NameSurname = student.NameSurname;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}