using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSample.Infrastructure.Mvc.Registries;

namespace ProjectSample.Infrastructure.Mvc.Filters
{
    public class DatabaseExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionRouteRegistry _exceptionRouteRegistry;

        public DatabaseExceptionFilter(IExceptionRouteRegistry exceptionRouteRegistry)
        {
            if (exceptionRouteRegistry == null) throw new ArgumentNullException(nameof(exceptionRouteRegistry));
            _exceptionRouteRegistry = exceptionRouteRegistry;
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (!_exceptionRouteRegistry.HasResultForException(filterContext.Exception)) return;

            var result = _exceptionRouteRegistry.CreateResultForException(filterContext.Exception);
            if (result != null)
            {

                filterContext.ExceptionHandled = true;
                if (filterContext.IsChildAction) return;
                filterContext.Result = result;
                filterContext.Result.ExecuteResult(filterContext);
            }
        }
    }


}