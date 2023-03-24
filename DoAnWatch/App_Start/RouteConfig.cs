using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnWatch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "danh-muc-san-pham/{action}",
              
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional },
                namespaces :new[] { "DoAnWatch.Controllers"} 

            );
            routes.MapRoute(
              name: "Products",
              url: "danh-muc-san-pham/{id}.html",

              defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "DoAnWatch.Controllers" }


          ); routes.MapRoute(
              name: "ShoppingCart",
              url: "Shopping-Cart",

              defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "DoAnWatch.Controllers" }


          );

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",

             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "DoAnWatch.Controllers" }

         );
        }
    }
}
