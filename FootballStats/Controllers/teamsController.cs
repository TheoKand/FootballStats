using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoalsWeb.Models;

namespace GoalsWeb.Controllers
{
    public class teamsController : Controller
    {
        private mochahost db = new mochahost();
        public readonly int PAGE_SIZE = 20;

        public JsonResult GetTeams()
        {
            List<team> allTeams = db.teams.ToList();
            var simpleTeamList = allTeams.Select(x => new { name = x.name, tournamentId = x.domesticTournamentId, rating = x.calcDomesticRating ,gf = (x.calcDomesticHomeAttackPerGame + x.calcDomesticAwayAttackPerGame) / 2, ga = (x.calcDomesticHomeDefencePerGame + x.calcDomesticAwayDefencePerGame) / 2 }).ToList();
            return Json(simpleTeamList, JsonRequestBehavior.AllowGet);
        }

        // GET: teams
        public async Task<ActionResult> Index()
        {
            ViewBag.allRegions = db.regions.ToList();
            ViewBag.allTournaments = db.tournaments.ToList();

            return View();
        }


        public async Task<ActionResult> DetailsByName(string name,int? page)
        {

            ViewBag.allRegions = db.regions.ToList();
            ViewBag.allTournaments = db.tournaments.ToList();
            ViewBag.honours = db.seasons.Where(s => s.championTeam.name == name).OrderByDescending (s=>s.year);

            if (string.IsNullOrWhiteSpace(name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team team = await db.teams.FirstOrDefaultAsync(t => t.name.ToLower() == name.ToLower());
            if (team == null)
            {
                return HttpNotFound();
            }

            #region get this page of team matches
            List<fmatch> matches = team.matchesAsHomeTeam.Union(team.matchesAsAwayTeam).OrderByDescending(m => m.matchDate).ToList();
            ViewBag.matchesVisible = page!=null;
            page = page ?? 1;
            List<fmatch> pagedMatches = matches.Skip(PAGE_SIZE * ((int)page - 1)).Take(PAGE_SIZE).ToList();
            ViewBag.pagesMatches = pagedMatches;
            ViewBag.page = page;
            ViewBag.totalPages = Math.Abs(matches.Count / PAGE_SIZE) + ((matches.Count % PAGE_SIZE) != 0 ? 1 : 0);
            #endregion

            #region statistics
            ViewBag.wins = matches.Where(m => m.winnerTeamId == team.id).Count();
            ViewBag.loses = matches.Where(m => m.loserTeamId  == team.id).Count();
            ViewBag.draws = matches.Where(m => m.winnerTeamId ==null && m.loserTeamId ==null ).Count();

            ViewBag.greatestWin = matches.Where(m => m.winnerTeamId == team.id).OrderByDescending(m => m.homeTeamScore - m.awayTeamScore).Take(1).ToList()[0];
            ViewBag.worstLoss = matches.Where(m => m.loserTeamId == team.id).OrderByDescending(m => m.homeTeamScore - m.awayTeamScore).Take(1).ToList()[0];

            #endregion

            return View(team);
        }


        public async Task<ContentResult> GetTeamDomesticRatingPosition(int? id)
        {
            ViewBag.allRegions = db.regions.ToList();

            team team = await db.teams.FindAsync(id);
            string result = "";
            if (team != null && team.calcDomesticRating!=0)
            {
                #region get all teams of this region
                var ratingsOfThisCountrysTeams = db.teams.Where(t => t.regionId == team.regionId && t.calcDomesticRating >0 ).OrderByDescending(t=>t.calcDomesticRating).Select(t=>t.calcDomesticRating).ToList() ;
                int position = ratingsOfThisCountrysTeams.IndexOf(team.calcDomesticRating)+1;
                result = string.Format("#{0} in {1}", position, team.region.name);
                result = string.Format("<a href='{0}'>{1}</a>", Url.Action("Index", "rating", new { type = "domestic", countryName=team.region.name, teamName = team.name }), result);
                #endregion
            }

            return Content(result);

        }

        public async Task<ContentResult> GetTeamInternationalRatingPosition(int? id)
        {
            team team = await db.teams.FindAsync(id);
            string result = "";
            if (team != null && team.calcInternationalRating!=0)
            {
                #region get all teams
                var ratings = db.teams.Where(t=> t.calcInternationalRating > 0).OrderByDescending(t => t.calcInternationalRating ).Select(t => t.calcInternationalRating).ToList();
                int position = ratings.IndexOf(team.calcInternationalRating) + 1;
                result = string.Format("#{0} in World", position);
                result = string.Format("<a href='{0}'>{1}</a>", Url.Action("Index", "rating", new { type = "international", countryName = team.region.name, teamName = team.name }), result);
                #endregion
            }

            return Content(result);

        }

        public async Task<ContentResult> GetTeamTotalRatingPosition(int? id)
        {
            team team = await db.teams.FindAsync(id);
            string result = "";
            if (team != null)
            {
                #region get all teams of this region
                var ratingsOfThisCountrysTeams = db.teams.Where(t => t.calcTotalRating > 0).OrderByDescending(t => t.calcTotalRating ).Select(t => t.calcTotalRating).ToList();
                int position = ratingsOfThisCountrysTeams.IndexOf(team.calcTotalRating) + 1;
                result = string.Format("#{0} in World", position);
                result = string.Format("<a href='{0}'>{1}</a>",Url.Action("Index", "rating", new { type = "total", countryName = team.region.name, teamName = team.name }),result);

                #endregion
            }

            return Content(result);

        }

    }


}
 