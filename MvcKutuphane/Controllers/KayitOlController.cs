using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        ProjeaDBEntities db = new ProjeaDBEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}