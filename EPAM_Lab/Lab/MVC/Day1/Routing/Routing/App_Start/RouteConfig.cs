
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Namespace priority
            routes.MapRoute(
                name: "RemoteNamespace",
                url: "{controller}/{action}",
                defaults: new {controller = "Home", action = "Index"},
                namespaces: new[] { "RemoteLib" }
            );
            

            //Remote controller with custom constraint
            routes.MapRoute(
                name: "CustomConstraint",
                url: "Home/Name/{name}",
                defaults: new { controller = "Home", action = "Name", name = UrlParameter.Optional },
                constraints: new { name = new ExpectedValueConstrains("kate", "jane", "tom") },
                namespaces: new[] { "RemoteLib" }
            );

            //Default routes
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

           
        }
    }
}
