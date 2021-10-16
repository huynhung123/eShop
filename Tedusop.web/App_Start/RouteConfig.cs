using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tedusop.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           routes.MapRoute(
           name: "Account",
           url: "dang-nhap.html",
           defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
           namespaces: new string[] { "Tedusop.web.Controllers" }
       );

            routes.MapRoute(
            name: "About",
            url: "gioi-thieu.html",
            defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
             namespaces: new string[] { "Tedusop.web.Controllers" }
        );

            routes.MapRoute(
              name: "Product Category",
              url: "{alias}.PC-{id}.html",
              defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
               namespaces: new string[] { "Tedusop.web.Controllers" }
          );
            routes.MapRoute(
             name: "Product",
             url: "{alias}.P-{id}.html",
             defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
              namespaces: new string[] { "Tedusop.web.Controllers" }
         );

            routes.MapRoute(
               name: "trangchu",
               url: "trang-chu.html",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Tedusop.web.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Tedusop.web.Controllers" }
            );
        }
    }
}
