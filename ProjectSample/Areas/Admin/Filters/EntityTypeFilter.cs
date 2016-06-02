using System.Web.Mvc;
using ProjectSample.Infrastructure.Extensions;

namespace ProjectSample.Areas.Admin.Filters
{
    public class EntityTypeFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.EntityType = (filterContext.RouteData.Values["controller"] as string).Capitalize();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}