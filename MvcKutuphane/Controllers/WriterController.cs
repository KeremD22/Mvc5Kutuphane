using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class WriterController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_YAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(TBL_YAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("WriterAdd");
            }
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return View();

        }
        public ActionResult WriterDelete(int id)
        {
            var deger = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult WriterBring(int id)
        {
            var ktg = db.TBL_YAZAR.Find(id);
            return View("WriterBring", ktg);
        }
        public ActionResult WriterUpdate(TBL_YAZAR p)
        {
            var ktg = db.TBL_YAZAR.Find(p.ID);
            ktg.AD = p.AD;
            ktg.SOYAD = p.SOYAD;
            ktg.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}