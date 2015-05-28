using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NerdDinner1._4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
 
             routes.MapRoute( 
                    "UpcomingDinners", 
                    "Dinners/Page/{page}", 
                    new { controller = "Dinners", action = "Index" } 
             ); 
            
            routes.MapRoute(
                name: "Default", // Route name
                url: "{controller}/{action}/{id}", // URL w/ params
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ); // Param defaults
        }
    }
}
