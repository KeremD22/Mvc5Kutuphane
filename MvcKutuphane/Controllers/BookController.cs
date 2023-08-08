using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class BookController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBL_KITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
           
            return View(kitaplar.ToList());
        }
            [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(TBL_KITAP p)
        {
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yzr = db.TBL_YAZAR.Where(k => k.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            db.TBL_KITAP.Add(p);
            db.SaveChanges();
            return View();

        }
        public ActionResult BookDelete(int id)
        {
            var kitap = db.TBL_KITAP.Find(id);
            db.TBL_KITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookBring(int id)
        {
            var ktg = db.TBL_KITAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("BookBring", ktg);
        }
        public ActionResult BookUpdate(TBL_KITAP p)
        {
            var kitap = db.TBL_KITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.DURUM = true;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yzr = db.TBL_YAZAR.Where(y => y.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}