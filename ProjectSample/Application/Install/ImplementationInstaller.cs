using System;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Application.Install.Base;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Application.Install
{
    public class ImplementationInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Action<Assembly> action = asm =>
                container.Register(
                    Classes.FromAssembly(asm)
                        .Where(t => t.Namespace != null && t.Namespace.EndsWith(".Impl"))
                        .LifestylePerWebRequest()
                        .WithServiceFirstInterface());
            action.VisitAssemblies(AssemblyConfiguration);

            container.Register(
                Component.For<AuthorizeAttribute>()
                );
        }
    }
}