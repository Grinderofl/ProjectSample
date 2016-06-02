using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Mvc;

namespace ProjectSample
{
    public class MvcApplication : HttpApplication
    {
        protected static IWindsorContainer Container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Initialize();
            SetControllerFactory();
        }

        private static void SetControllerFactory()
        {
            var controllerFactory = new WindsorControllerFactory(Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        private static void Initialize()
        {
            Container = new WindsorContainer();
            Container.AddFacility<TypedFactoryFacility>();
            Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel, true));
            Container.Install(FromAssembly.This());
        }

        protected void Application_End()
        {
            Container.Dispose();
        }
    }
}