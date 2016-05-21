using System.Web.Mvc;
using ProjectSample.Areas.Home.Controllers;

namespace ProjectSample.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Home";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Default_home",
                "",
                new {controller = "Home", action = "Index"},
                new[] {typeof(HomeController).Namespace});

            context.MapRoute(
                "Default",
                "Home/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] {typeof(HomeController).Namespace}
            );
        }
    }
}