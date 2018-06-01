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
    public class partiteController : Controller
    {
        private sportEntities db = new sportEntities();

        // GET: partite
        public ActionResult Index(int id)
        {
            var matches = db.matches.Include(m => m.competitions).Include(m => m.teams).Include(m => m.teams1);
            matches = matches.Where(x =>x.idCompetition == id);
            matches.OrderByDescending(x => x.date);
            return View(matches.ToList());
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
