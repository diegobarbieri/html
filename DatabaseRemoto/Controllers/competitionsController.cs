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
    public class competitionsController : Controller
    {
        private sportEntities db = new sportEntities();

        // GET: competitions
        public ActionResult Index(int id)
        {
            var competitions = db.competitions.Include(c => c.leagues).Include(c => c.seasons);
            competitions = competitions.Where(x => x.idLeague == id);
            competitions.OrderByDescending(x => x.name);
            return View(competitions.ToList());
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
