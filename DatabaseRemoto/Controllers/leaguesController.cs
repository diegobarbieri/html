using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseRemoto.Models;

namespace DatabaseRemoto.Controllers
{
    public class leaguesController : Controller
    {
        private sportEntities db = new sportEntities();

        // GET: leagues
        public ActionResult Index()
        {
            var leagues = db.leagues.Include(l => l.nations);
            leagues = leagues.Where(x => x.nation_id == 596);
            leagues = leagues.OrderByDescending(x => x.name);
            return View(leagues.ToList());
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
