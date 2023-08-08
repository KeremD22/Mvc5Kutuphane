using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class ÜyeController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();
        // GET: Üye
        public ActionResult Index(int sayfa=1)
        {
      
            var degerler = db.TBL_UYELER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ÜyeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÜyeAdd(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {

                return View("ÜyeAdd");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult ÜyeDelete(int id)
        {
            var kategori = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeBring(int id)
        {
            var ktg = db.TBL_UYELER.Find(id);
            return View("ÜyeBring", ktg);
        }
        public ActionResult ÜyeUpdate(TBL_UYELER p)
        {
            var ktg = db.TBL_UYELER.Find(p.ID);
            ktg.AD = p.AD;
            ktg.SOYAD = p.SOYAD;
            ktg.MAIL = p.MAIL;
            ktg.KULLANICIADI = p.KULLANICIADI;
            ktg.SIFRE = p.SIFRE;
            ktg.OKUL = p.OKUL;
            ktg.TELEFON = p.TELEFON;
            ktg.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeKitapGecmis(int id)
        {
            var ktpgcms = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBL_UYELER.Where(y => y.ID == id).Select(z => z.AD + "" + z.SOYAD).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);
        }
    }
}