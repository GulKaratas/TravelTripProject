using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Class;
namespace TravelTripProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
           c.Blogs.Add(p);
              c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var blg = c.Blogs.Find(id);
            return View("BlogGetir", blg);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Comments.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var yorum = c.Comments.Find(id);
            c.Comments.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Comments.Find(id);
            return View("YorumGetir", yrm);
        }
        public ActionResult YorumGuncelle(Comments y)
        {
            var yrm = c.Comments.Find(y.Id);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}