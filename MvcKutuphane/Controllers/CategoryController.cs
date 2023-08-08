using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class CategoryController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORI.Where(x => x.DURUM == true).ToList();
            return View(degerler);
        }
         [HttpGet]
        public ActionResult CategoryAdd()
        {       
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TBL_KATEGORI p)
        {
            db.TBL_KATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult CategoryDelete(int id)
        {
            var kategori = db.TBL_KATEGORI.Find(id);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryUpdate(int id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);
            return View("CategoryUpdate", ktg);
        }
        public ActionResult CategoryUpdate1(TBL_KATEGORI p)
        {
            var ktg = db.TBL_KATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}