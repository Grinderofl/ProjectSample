using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Mvc;
using FluentValidation.Mvc;
using ProjectSample.Infrastructure.FluentValidation.Windsor;

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
            SetValidatorProvider();
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

        private static void SetValidatorProvider()
        {
            var validatorFactory = new WindsorFluentValidatorFactory(Container.Kernel);
            //FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = validatorFactory);

            var validatorProvider = new FluentValidationModelValidatorProvider(validatorFactory);
            ModelValidatorProviders.Providers.Add(validatorProvider);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }

        protected void Application_End()
        {
            Container.Dispose();
        }
    }
}