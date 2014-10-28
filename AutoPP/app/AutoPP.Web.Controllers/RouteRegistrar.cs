using System.Web.Mvc;
using System.Web.Routing;
using Castle.Facilities.WcfIntegration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using AutoPP.ApplicationServices;
using AutoPP.ApplicationServices.Impl;

namespace AutoPP.Web.Controllers
{
    public class RouteRegistrar
    {
        public static void RegisterRoutesTo(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("css/{*pathInfo}");
            routes.IgnoreRoute("images/{*pathInfo}");
            

            routes.MapRoute(
                "Search",                                              // Route name
                "Search/{action}/{id}/{title}",                           // URL with parameters
                new { controller = "Search", action = "Index", id = UrlParameter.Optional, title = UrlParameter.Optional }  // Parameter defaults
            );
            
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Search", action = "Index", id = UrlParameter.Optional }  // Parameter defaults
            );
        }
    }
}
