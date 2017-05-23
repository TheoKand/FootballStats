using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoalsWeb.Models;

namespace GoalsWeb.Controllers
{
    public class matchController : Controller
    {

        private mochahost db = new mochahost();

        public ActionResult Details(int id)
        {
            ViewBag.allRegions = db.regions.ToList();
            ViewBag.allTournaments = db.tournaments.ToList();

            fmatch match = db.fmatches.FirstOrDefault(m => m.id == id);
            if (match == null)
            {
                return HttpNotFound();
            }

            ViewBag.events = db.matchevents.Where(m => m.matchId == id).ToList();

            return View(match);
        }
    }
}