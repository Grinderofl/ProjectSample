using System;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Core.Install.Base;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Core.Install
{
    public class CommandBusInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICommandHandlerFactory>().AsFactory().LifestylePerWebRequest());
            Action<Assembly> action = asm =>
                container.Register(
                    Classes.FromAssembly(asm).BasedOn(typeof(IHandleCommand<>)).WithServiceBase().LifestyleTransient());
            action.VisitAssemblies(AssemblyConfiguration);
        }
    }
}