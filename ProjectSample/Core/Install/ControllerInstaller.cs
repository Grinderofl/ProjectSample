using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Core.Install.Base;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Core.Install
{
    public class ControllerInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Action<Assembly> action = asm =>
                container.Register(Classes.FromAssembly(asm)
                    .BasedOn<IController>()
                    .LifestyleTransient());
            action.VisitAssemblies(AssemblyConfiguration);
        }
    }
}