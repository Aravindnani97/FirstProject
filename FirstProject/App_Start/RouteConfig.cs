using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name:"MovieByNameAndReleaseDate",
            //    url:"{controller}/{action}/{name}/{releaseDate}",
            //    defaults:new{ Controller="Movies",action="SearchMovie",releaseDate=UrlParameter.Optional}
            //    );
            //routes.MapRoute(
            //    name: "CustomerByDOB",
            //    url: "{controller}/{action}/{DOB}",
            //   defaults: new { Controller = "Customer", action = "FindAge", DOB = "06/16/1997" }

            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
        }
    }
}
