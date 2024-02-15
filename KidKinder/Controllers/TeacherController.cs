using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class TeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }
    }
}