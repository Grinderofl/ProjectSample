using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentMvc;
using FluentMvc.ActionResultFactories;
using FluentMvc.Conventions;
using FluentMvc.Utils;
using ProjectSample.Infrastructure.FluentMvc;
using ProjectSample.Infrastructure.FluentMvc.Windsor;

namespace ProjectSample.Core.Install
{
    public class FluentMvcInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .Where(x => !string.IsNullOrEmpty(x.Namespace) && x.Namespace.EndsWith("Filters")));

            container.Register(Classes.FromThisAssembly().Where(x => x.CanBeCastTo<IFilterConvention>()));

            var provider = FluentMvcConfiguration.ConfigureFilterProvider(c =>
            {
                c.ResolveWith(new WindsorObjectFactory(container));
                c.WithResultFactory<ActionResultFactory>()
                    .WithResultFactory<ViewResultFactory>(true);
                c.FilterConventions.SetConventionActivator(new WindsorConventionActivator(container));
                c.FilterConventions.LoadFromAssemblyContaining<FluentMvcInstaller>();
            });

            FilterProviders.Providers.Add(new ProjectSampleFilterProvider(provider));
        }
    }
}