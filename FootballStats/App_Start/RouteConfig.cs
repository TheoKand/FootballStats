using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoalsWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Season",
                url: "season/{name}/{year}",
                defaults: new { controller = "season", action = "Details",year=UrlParameter.Optional  }
            );

            routes.MapRoute(
                name: "Rating",
                url: "rating/{type}/{countryName}/{teamName}",
                defaults: new { controller = "rating", action = "Index", teamName = UrlParameter.Optional,countryName=UrlParameter.Optional  }
            );

            routes.MapRoute(
                name: "AllTeams",
                url: "allteams",
                defaults: new { controller = "teams", action = "Index" }
            );

            routes.MapRoute(
                name: "TeamInfo",
                url: "team/details/{name}",
                defaults: new { controller = "teams", action = "DetailsByName" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
