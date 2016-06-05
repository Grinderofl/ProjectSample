using System;
using System.Web.Mvc;

namespace ProjectSample.Infrastructure.Mvc.Registries
{
    public interface IExceptionRouteRegistry
    {
        ActionResult CreateResultForException(Exception exception);
        bool HasResultForException(Exception exception);
    }
}