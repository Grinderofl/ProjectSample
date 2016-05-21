using System.Web.Mvc;
using ProjectSample.Areas.Catalog.Controllers;

namespace ProjectSample.Areas.Catalog
{
    public class CatalogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Catalog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Catalog_default",
                "Catalog/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] {typeof(HomeController).Namespace}
            );
        }
    }
}