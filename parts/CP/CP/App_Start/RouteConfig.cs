using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("*.json");
            

            routes.MapRoute(
                name: "Query",
                url: "Search/Query/{category}/{brand}/{model}/{year}/{area}/{text}/{stamp}",
                defaults: new { controller = "Search", action = "Query", category = -1, brand = -1, model = UrlParameter.Optional, year = -1, area = UrlParameter.Optional, text = UrlParameter.Optional, stamp = string.Empty });

            routes.MapRoute(name: "Detail", url: "Search/Get/{itemId}/{stamp}",
                defaults: new { controller = "Search", action = "Get", itemId = -1, stamp = string.Empty });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
