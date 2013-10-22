using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cik.MagazineWeb.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Category",
            //    url: "{controller}/{action}/{name}/{id}",
            //    defaults: new { controller = "Home", action = "Category" }
            //);

            //routes.MapRoute(
            //    name: "Item",
            //    url: "{controller}/{action}/{title}/{categoryId}/{itemId}",
            //    defaults: new { controller = "Home", action = "Details" }
            //);

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
