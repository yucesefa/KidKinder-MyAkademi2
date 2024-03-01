using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class BranchController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Branches.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(Branch branch)
        {
            var values = context.Branches.Add(branch);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBranch(int id)
        {
            var values = context.Branches.Find(id);
            context.Branches.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBranch(int id)
        {
            var values = context.Branches.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateBranch(Branch branch)
        {
            var values = context.Branches.Find(branch.BranchId);
            values.BranchName = branch.BranchName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}