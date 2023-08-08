using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();
        // GET: Personel
        public ActionResult Index()
        {

            var degerler = db.TBL_PERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelAdd(TBL_PERSONEL p)
        {
            if (!ModelState.IsValid)
            {
 
                    return View("PersonelAdd");   
            }
            db.TBL_PERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelDelete(int id)
        {
            var kategori = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelBring(int id)
        {
            var ktg = db.TBL_PERSONEL.Find(id);
            return View("PersonelBring", ktg);
        }
        public ActionResult PersonelUpdate(TBL_PERSONEL p)
        {
            var ktg = db.TBL_PERSONEL.Find(p.ID);
            ktg.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}