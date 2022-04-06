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
    public class SalgsudbudSetsController : Controller
    {
        private AuktionsEntities db = new AuktionsEntities();

        // GET: SalgsudbudSets
        public ActionResult Index(string emailen)
        {
            ViewBag.emailen = emailen;
            return View(db.SalgsudbudSet.ToList());
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
