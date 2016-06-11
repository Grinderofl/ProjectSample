using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Microsoft.Owin;

namespace ProjectSample.EF.Infrastructure.Windsor
{
    public class WindsorMiddleware : OwinMiddleware
    {
        private readonly IWindsorContainer _resolver;

        public WindsorMiddleware(OwinMiddleware next, IWindsorContainer resolver) : base(next)
        {
            _resolver = resolver;
        }

        public override async Task Invoke(IOwinContext context)
        {
            using (_resolver.BeginScope())
            {
                await Next.Invoke(context);
            }
        }
    }
}