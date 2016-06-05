using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectSample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Boot",
                "boot/{action}/{id}", new {controller = "Boot", action = "Index", id = UrlParameter.Optional});
        }
    }
}
