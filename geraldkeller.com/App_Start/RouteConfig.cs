using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace geraldkeller.com
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
      name: "Resume",
      url: "api/Resume/get",
      defaults: new { controller = "Resume", action = "Get" }
      );

      routes.MapRoute(
      name: "User",
      url: "api/User/create",
      defaults: new { controller = "User", action = "Create" }
      );

      routes.MapRoute(
            name: "Default",
            url: "{*anything}",
            defaults: new { controller = "Home", action = "Index"}
            );
    }
  }
}
