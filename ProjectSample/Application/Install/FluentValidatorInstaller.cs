using System;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;
using ProjectSample.Application.Install.Base;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Application.Install
{
    public class FluentValidatorInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Action<Assembly> action = asm =>
                container.Register(
                    Classes.FromAssembly(asm).BasedOn(typeof(IValidator<>)).WithServiceBase().LifestylePerWebRequest());
            action.VisitAssemblies(AssemblyConfiguration);
        }
    }
}