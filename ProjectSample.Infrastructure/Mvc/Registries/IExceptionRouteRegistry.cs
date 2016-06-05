using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectSample.Infrastructure.Mvc.Registries
{
    public interface IExceptionRouteRegistry
    {
        ActionResult CreateResultForException(Exception exception);
        bool HasResultForException(Exception exception);
    }
}
