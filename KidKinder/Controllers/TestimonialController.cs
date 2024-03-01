using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class TestimonialController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.SaveChanges();
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonials.Find(testimonial.TestimonialId);
            values.NameSurname = testimonial.NameSurname;
            values.Title = testimonial.Title;
            values.Comment = testimonial.Comment;
            values.ImageUrl = testimonial.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}