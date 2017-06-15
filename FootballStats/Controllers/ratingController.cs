using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoalsWeb.Models;

namespace GoalsWeb.Controllers
{
    public class ratingController : BaseController
    {

        // GET: rating
        public ActionResult Index(string type, string teamName,string countryName)
        {

            team team = db.teams.FirstOrDefault(t => t.name.ToLower() == teamName.ToLower());
            region region = db.regions.FirstOrDefault(r => r.name.ToLower() == countryName.ToLower());

            ViewBag.team = team;
            ViewBag.country = region;
            ViewBag.type = type;

            #region get international ratings and optionally the specified team's position
            List<team> internationalRatings = db.teams.Where(t => t.calcInternationalRating > 0).OrderByDescending(t => t.calcInternationalRating).ToList();
            ViewBag.internationalRatings = internationalRatings;
            if (team != null && team.calcInternationalRating != 0)
            {
                int position = internationalRatings.Select(t => t.calcInternationalRating).ToList().IndexOf(team.calcInternationalRating) + 1;
                ViewBag.internationalTeamPosition = string.Format("#{0} in World", position);
            }
            #endregion

            #region get domestic ratings and optionally the specified team's position
            if (region!=null) {
                List<team> domesticRatings = db.teams.Where(t => t.regionId == region.id).OrderByDescending(t => t.calcDomesticRating).ThenBy (t=>t.name).ToList();


                ViewBag.domesticRatings = domesticRatings;
                if (team != null && team.calcDomesticRating != 0)
                {
                    int position = domesticRatings.Select(t => t.calcDomesticRating).ToList().IndexOf(team.calcDomesticRating) + 1;
                    ViewBag.domesticTeamPosition = string.Format("#{0} in {1}", position, team.region.name);
                }
            }
            #endregion

            #region get total ratings and optionally the specified team's position
            List<team> totalRatings = db.teams.Where(t => t.calcTotalRating > 0).OrderByDescending(t => t.calcTotalRating).ToList();
            ViewBag.totalRatings = totalRatings;

            if (team != null && team.calcTotalRating != 0)
            {
                int position = totalRatings.Select(t => t.calcTotalRating).ToList().IndexOf(team.calcTotalRating) + 1;
                ViewBag.totalTeamPosition = string.Format("#{0} in total", position);
            }
            #endregion

            return View();
        }
    }
}