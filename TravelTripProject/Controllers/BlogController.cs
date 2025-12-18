using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Class;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogComments bc = new BlogComments();
        public ActionResult Index()
        {
            bc.Deger1 = c.Blogs.ToList();
            bc.Deger3 = c.Blogs.OrderByDescending(x => x.Tarih).Take(3).ToList();
            return View(bc);
        }
        
        public ActionResult BlogDetalis(int id)
        {
            bc.Deger1 = c.Blogs.Where(x => x.Id == id).ToList();
            bc.Deger2 = c.Comments.Where(x => x.BlogId == id).ToList();
            bc.Deger3 = c.Blogs.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(bc);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
       public PartialViewResult YorumYap(Comments comments)
        {
            c.Comments.Add(comments);
            c.SaveChanges();
            return PartialView();
        }
    }
}