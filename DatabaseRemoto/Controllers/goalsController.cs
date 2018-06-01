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
    public class goalsController : Controller
    {
        private sportEntities db = new sportEntities();

        // GET: goals
        public ActionResult Index()
        {
            var goals = db.goals.Include(g => g.matches).Include(g => g.players).Include(g => g.teams);
            return View(goals.ToList());
        }

        // GET: goals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            goals goal = db.goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        // GET: goals/Create
        public ActionResult Create()
        {
            ViewBag.idMatch = new SelectList(db.matches, "id", "round");
            ViewBag.idPlayer = new SelectList(db.players, "id", "name");
            ViewBag.idTeam = new SelectList(db.teams, "id", "name");
            return View();
        }

        // POST: goals/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idMatch,minuto,idPlayer,idTeam,isPenalty,isOwnGoal")] goals goal)
        {
            if (ModelState.IsValid)
            {
                db.goals.Add(goal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMatch = new SelectList(db.matches, "id", "round", goal.idMatch);
            ViewBag.idPlayer = new SelectList(db.players, "id", "name", goal.idPlayer);
            ViewBag.idTeam = new SelectList(db.teams, "id", "name", goal.idTeam);
            return View(goal);
        }

        // GET: goals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            goals goal = db.goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMatch = new SelectList(db.matches, "id", "round", goal.idMatch);
            ViewBag.idPlayer = new SelectList(db.players, "id", "name", goal.idPlayer);
            ViewBag.idTeam = new SelectList(db.teams, "id", "name", goal.idTeam);
            return View(goal);
        }

        // POST: goals/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idMatch,minuto,idPlayer,idTeam,isPenalty,isOwnGoal")] goals goal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMatch = new SelectList(db.matches, "id", "round", goal.idMatch);
            ViewBag.idPlayer = new SelectList(db.players, "id", "name", goal.idPlayer);
            ViewBag.idTeam = new SelectList(db.teams, "id", "name", goal.idTeam);
            return View(goal);
        }

        // GET: goals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            goals goal = db.goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        // POST: goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            goals goal = db.goals.Find(id);
            db.goals.Remove(goal);
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
