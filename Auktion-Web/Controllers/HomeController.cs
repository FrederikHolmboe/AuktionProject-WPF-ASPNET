using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuktionsEntity.Model;

namespace Auktion_Web.Controllers
{
    public class HomeController : Controller
    {
        private AuktionsEntities db = new AuktionsEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string navn, string tlf, string email)
        {
            
            KundeSet kunde = db.KundeSet.Find(email);
            if (kunde == null)
            {
                kunde = new KundeSet
                {
                    Navn = navn,
                    Tlf = Int32.Parse(tlf),
                    Email = email,
                };

                db.KundeSet.Add(kunde);

                db.SaveChanges();
                return RedirectToAction("Index", "SalgsudbudSets", new { emailen = email });
            }
            return RedirectToAction("Index", "SalgsudbudSets", new { emailen = email });

        }
    }
}