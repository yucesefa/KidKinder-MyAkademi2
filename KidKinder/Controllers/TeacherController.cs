using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTeacher()
        {
            List<SelectListItem> values = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BranchName,
                                               Value = x.BranchId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }
        public ActionResult DeleteTeacher(int id)
        {
            var values = context.Teachers.Find(id);
            context.Teachers.Remove(values);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            List<SelectListItem> valueslist = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BranchName,
                                               Value = x.BranchId.ToString()
                                           }).ToList();
            ViewBag.v = valueslist;
            var values = context.Teachers.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            var values = context.Teachers.Find(teacher.TeacherId);
            values.ImageUrl= teacher.ImageUrl;
            values.NameSurname= teacher.NameSurname;
            values.BranchId= teacher.BranchId;
            //values.Title= teacher.Title;
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }
    }
}