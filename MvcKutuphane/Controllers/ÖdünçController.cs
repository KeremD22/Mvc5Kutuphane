using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class ÖdünçController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBL_UYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in db.TBL_KITAP.Where(x => x.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in db.TBL_PERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpGet]
        public ActionResult OduncAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncAdd(TBL_HAREKET p)
        {
            var d1 = db.TBL_UYELER.Where(x => x.ID == p.TBL_UYELER.ID).FirstOrDefault();
            var d2 = db.TBL_KITAP.Where(x => x.ID == p.TBL_KITAP.ID).FirstOrDefault();
            var d3 = db.TBL_PERSONEL.Where(x => x.ID == p.TBL_PERSONEL.ID).FirstOrDefault();
            p.TBL_UYELER = d1;
            p.TBL_KITAP = d2;
            p.TBL_PERSONEL = d3;
            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OduncDelete(TBL_HAREKET p)
        {
            var ktg = db.TBL_HAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(ktg.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;

            return View("OduncDelete", ktg);


        }
        public ActionResult OduncUpdate(TBL_HAREKET p)
        {
            var ktg = db.TBL_HAREKET.Find(p.ID);
            ktg.UYEGETIRTARIH = p.UYEGETIRTARIH;
            ktg.ISLEMDURUM = p.ISLEMDURUM;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}