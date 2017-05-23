using GoalsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoalsWeb.Controllers
{
    public class HomeController : Controller
    {
        private mochahost db = new mochahost();

        public ActionResult Index()
        {
            ViewBag.allRegions = db.regions.ToList();
            ViewBag.allTournaments = db.tournaments.ToList();

            return View();
        }

    }
}