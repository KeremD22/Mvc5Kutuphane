using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;
namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ProjeaDBEntities db = new ProjeaDBEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
             var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                //TempData["id"] = bilgiler.ID.ToString();
                //TempData["Ad"] = bilgiler.AD.ToString();
                //TempData["Soyad"] = bilgiler.SOYAD.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgiler.SIFRE.ToString();
                //TempData["uni"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }

    }
}