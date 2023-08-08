using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class İslemController : Controller
    {
        ProjeaDBEntities db = new ProjeaDBEntities();
        public ActionResult Index()
        {

            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
    }
}