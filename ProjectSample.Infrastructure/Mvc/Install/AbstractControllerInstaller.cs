using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Infrastructure.Windsor;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Infrastructure.Mvc.Install
{
    public abstract class AbstractControllerInstaller<TConfiguration> : AbstractAssemblyInstaller<TConfiguration> where TConfiguration : AssemblyConfiguration, new()
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Action<Assembly> action = asm =>
                container.Register(Classes.FromAssembly(asm)
                    .BasedOn<IController>()
                    .Configure(x => x.Named(x.Implementation.Name))
                    .LifestyleTransient());
            action.VisitAssemblies(AssemblyConfiguration);
        }
    }
}