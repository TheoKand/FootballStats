using GoalsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoalsWeb.Controllers
{
    /// <summary>
    /// This is a base class for all controllers. It contains code that is nessecary for the layout of the website (footer). 
    /// </summary>
    public class BaseController : Controller
    {
        protected mochahost db = new mochahost();

        protected override void Initialize(RequestContext requestContext)
        {
            ViewBag.allRegions = db.regions.ToList();
            ViewBag.allTournaments = db.tournaments.ToList();

            base.Initialize(requestContext);
        }
    }
}