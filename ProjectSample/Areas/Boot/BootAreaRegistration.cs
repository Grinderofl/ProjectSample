using System.Web.Mvc;

namespace ProjectSample.Areas.Boot
{
    public class BootAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Boot";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Boot_default",
                "Boot/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}