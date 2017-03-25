using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GameCraft.Models;

namespace GameCraft
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // modern way to create custom rutes (Attribute Routes)

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            /*  Old way to make custom routes

               routes.MapRoute(
               name: "BoardgamesByType",           
               url: "Boardgames/Type/{type}",
               defaults: new {controller = "Boardgames", action = "BoardgameType" });

           */
        }
    }
}
