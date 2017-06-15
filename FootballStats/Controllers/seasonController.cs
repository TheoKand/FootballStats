using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoalsWeb.Models;
namespace GoalsWeb.Controllers
{
    public class seasonController : BaseController
    {

        // GET: season
        [HttpGet]
        public ActionResult Details(string name,int? year)
        {
            //initialize the year to 2015.
            year = year ?? 2015;

            season season = db.seasons.FirstOrDefault(s => s.tournament.name == name && s.year ==year);
            if (season == null)
            {
                return HttpNotFound();
            }

            ViewBag.years = db.seasons.Select(s => s.year).Distinct().ToList();

            return View(season);
        }

        /// <summary>
        /// This action is called when the GO button is pressed. It calls the main action with the specified parameters (Season and year)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Details()
        {

            string name = Request.Form["currentTournament"].ToString();
            int year = Convert.ToInt32(Request.Form["currentYear"]);

            return Details(name, year);
        }
    }
}