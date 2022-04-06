using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuktionsEntity.Model;

namespace Auktion_Web.Controllers
{
    public class KoebstilbudSetsController : Controller
    {
        private AuktionsEntities db = new AuktionsEntities();

        // GET: KoebstilbudSets
        public ActionResult Index()
        {
            var koebstilbudSet = db.KoebstilbudSet.Include(k => k.KundeSet).Include(k => k.SalgsudbudSet);
            return View(koebstilbudSet.ToList());
        }

        // GET: KoebstilbudSets/Create
        public ActionResult Create(string email, string id)
        {
            ViewBag.emailen = email;
            ViewBag.salgId = id;
            ViewBag.date = DateTime.Now;
            return View();
        }

        // POST: KoebstilbudSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KoebstilbudId,Pris,OpretningsDato,KundeSet,SalgsudbudSet")] KoebstilbudSet koebstilbudSet)
        {
            ViewBag.emailen = koebstilbudSet.KundeSet.Email;
            ViewBag.salgId = koebstilbudSet.SalgsudbudSet.SalgsudbudId;
            ViewBag.date = DateTime.Now;


            koebstilbudSet.KundeSet = db.KundeSet.Find(koebstilbudSet.KundeSet.Email);
            koebstilbudSet.SalgsudbudSet = db.SalgsudbudSet.Find(koebstilbudSet.SalgsudbudSet.SalgsudbudId);
           
           int max = (from num in db.KoebstilbudSet
                           where num.SalgsudbudSet.SalgsudbudId == koebstilbudSet.SalgsudbudSet.SalgsudbudId && num.Pris != 0
                           select num.Pris).DefaultIfEmpty(0).Max();
            
            if (ModelState.IsValid)
            {
                if (koebstilbudSet.SalgsudbudSet.Tidsfrist > DateTime.Now)
                {
                    if (max != 0)
                    {
                        if (max < koebstilbudSet.Pris)
                        {
                            db.KoebstilbudSet.Add(koebstilbudSet);
                            db.SaveChanges();
                            return RedirectToAction("Index", "SalgsudbudSets", new { emailen = koebstilbudSet.KundeSet.Email });
                        }
                        else
                        {
                            ModelState.AddModelError("KundeSet", "ERROR: Prisen skal være over max.");
                            return View(koebstilbudSet);
                        }

                    }
                    else
                    {   
                            db.KoebstilbudSet.Add(koebstilbudSet);
                            db.SaveChanges();
                            return RedirectToAction("Index", "SalgsudbudSets", new { emailen = koebstilbudSet.KundeSet.Email });
                    }
                }
                else
                {
                    ModelState.AddModelError("KundeSet","ERROR: Den er udløbet");
                    return View(koebstilbudSet);
                }


            }

            return View(koebstilbudSet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
