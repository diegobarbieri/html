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
    public class matchesController : Controller
    {
        private int calcolaPuntiSquadra(int id, List<matches> partite)
        {
            var punti = 0;
            var partiteCasa = partite.Where(x => x.idHome == id);
            var partiteTrasferta = partite.Where(x => x.idAway == id);
            //CALCOLIAMO I PUNTI IN CASA//
            foreach(var partita in partiteTrasferta)
            {
                if (partita.goalsHome < partita.goalsAway)
                {
                    punti += 3;
                }
                else if (partita.goalsHome == partita.goalsAway) 
                {
                    punti += 1;
                }
            }
            foreach (var partita in partiteCasa)
            {
                if (partita.goalsHome > partita.goalsAway)
                {
                    punti += 3;
                }
                else if (partita.goalsHome == partita.goalsAway) {
                    punti += 1;
                }
            }
            return punti;
        }
        private sportEntities db = new sportEntities();

        // GET: matches
        public ActionResult Index(int id)
        {
            var matches = db.matches.Include(m => m.competitions).Include(m => m.teams).Include(m => m.teams1);
            matches = matches.Where(x => x.idCompetition == id);
            matches = matches.OrderByDescending(x => x.date);

            var squadre = matches.Select(x => new Squadra { Nome = x.teams.name, Id= x.teams.id }).Distinct().ToList();
            var ViewModel = new ViewModelCampionato();
            foreach (var squadra in squadre)
            {
                ViewModel.Partite = matches.ToList();
                ViewModel.Squadre = squadre;
                var partite = matches.Where(x => x.idHome == squadra.Id || x.idAway == squadra.Id);
                squadra.Punti = calcolaPuntiSquadra(squadra.Id, partite.ToList());
            }
            return View(ViewModel);
        }

        // GET: matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matches match = db.matches.Find(id);
            
            if (match == null)
            {
                return HttpNotFound();
            }

            var goals = db.goals.Where(x => x.idMatch == id).ToList();
            match.goals = goals;
            return View(match);
        }

        // GET: matches/Create
        public ActionResult Create()
        {
            ViewBag.idCompetition = new SelectList(db.competitions, "id", "name");
            ViewBag.idHome = new SelectList(db.teams, "id", "name");
            ViewBag.idAway = new SelectList(db.teams, "id", "name");
            return View();
        }

        // POST: matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idCompetition,idHome,idAway,goalsHome,goalsAway,date,isRegular,isFullGoal,isExtraTime,round,link,stage")] matches match)
        {
            if (ModelState.IsValid)
            {
                db.matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.idCompetition = new SelectList(db.competitions, "id", "name", matches.idCompetition);
            //ViewBag.idHome = new SelectList(db.teams, "id", "name", matches.idHome);
            //ViewBag.idAway = new SelectList(db.teams, "id", "name", matches.idAway);
            return View(match);
        }

        // GET: matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matches match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            //ViewBag.idCompetition = new SelectList(db.competitions, "id", "name", match.idCompetition);
            //ViewBag.idHome = new SelectList(db.teams, "id", "name", match.idHome);
            //ViewBag.idAway = new SelectList(db.teams, "id", "name", match.idAway);
            return View(match);
        }

        // POST: matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idCompetition,idHome,idAway,goalsHome,goalsAway,date,isRegular,isFullGoal,isExtraTime,round,link,stage")] matches match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.idCompetition = new SelectList(db.competitions, "id", "name", match.idCompetition);
            //ViewBag.idHome = new SelectList(db.teams, "id", "name", match.idHome);
            //ViewBag.idAway = new SelectList(db.teams, "id", "name", match.idAway);
            return View(match);
        }

        // GET: matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matches match = db.matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            matches match = db.matches.Find(id);
            db.matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
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
