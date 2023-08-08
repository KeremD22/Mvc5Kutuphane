using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim

        ProjeaDBEntities db = new ProjeaDBEntities();
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        
    }
}