using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentMvc;
using FluentMvc.ActionResultFactories;
using FluentMvc.Conventions;
using FluentMvc.Utils;
using ProjectSample.Application.Install.Base;
using ProjectSample.Infrastructure.FluentMvc;
using ProjectSample.Infrastructure.FluentMvc.Windsor;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Application.Install
{
    public class FluentMvcInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterFilters(container);
            RegisterFilterConventions(container);
            ConfigureFilterProvider(container);
        }

        private static void ConfigureFilterProvider(IWindsorContainer container)
        {
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

        private void RegisterFilterConventions(IWindsorContainer container)
        {
            Action<Assembly> action = asm =>
                            container.Register(Classes.FromAssembly(asm).Where(x => x.CanBeCastTo<IFilterConvention>()));
            action.VisitAssemblies(AssemblyConfiguration);
        }

        private void RegisterFilters(IWindsorContainer container)
        {
            Action<Assembly> action = asm =>
                            container.Register(
                                Classes.FromAssembly(asm)
                                    .Where(x => !string.IsNullOrEmpty(x.Namespace) && x.Namespace.EndsWith("Filters")));
            action.VisitAssemblies(AssemblyConfiguration);
        }
    }
}