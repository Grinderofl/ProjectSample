using System.ComponentModel;
using System.Web.Mvc;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Mvc;
using FluentValidation.Mvc;
using Microsoft.Owin;
using Owin;
using ProjectSample.EF.Infrastructure.Windsor;
using ProjectSample.Infrastructure.FluentValidation.Windsor;

[assembly: OwinStartupAttribute(typeof(ProjectSample.EF.Startup))]
namespace ProjectSample.EF
{
    public partial class Startup
    {
        public static WindsorContainer Container;

        public void Configuration(IAppBuilder app)
        {
            ConfigureContainer(app);
            ConfigureAuth(app);
            
            SetControllerFactory();
            SetValidatorProvider();
        }

        private void ConfigureContainer(IAppBuilder app)
        {
            Container = new WindsorContainer();
            Container.AddFacility<TypedFactoryFacility>();
            Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));
            Container.Install(FromAssembly.This());
            app.Use<WindsorMiddleware>(Container);
        }

        private static void SetValidatorProvider()
        {
            //var validatorFactory = new WindsorFluentValidatorFactory(Container.Kernel);
            //var validatorProvider = new FluentValidationModelValidatorProvider(validatorFactory);
            //ModelValidatorProviders.Providers.Add(validatorProvider);
            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }

        private static void SetControllerFactory()
        {
            var controllerFactory = new WindsorControllerFactory(Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
