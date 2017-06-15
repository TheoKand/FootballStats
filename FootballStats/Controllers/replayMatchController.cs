using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoalsWeb.Models;

namespace GoalsWeb.Controllers
{
    public class replayMatchController : BaseController
    {

        public ActionResult Details(int id)
        {

            fmatch match = db.fmatches.FirstOrDefault(m => m.id == id);
            if (match == null)
            {
                return HttpNotFound();
            }

            //The list of entries from table matchEvents
            ViewBag.events = db.matchevents.Where(m => m.matchId == id).ToList();

            return View(match);
        }
    }
}