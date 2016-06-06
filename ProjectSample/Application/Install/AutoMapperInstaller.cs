using System;
using System.Reflection;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Application.Install.Base;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Application.Install
{
    public class AutoMapperInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {


            Mapper.Initialize(conf =>
            {
                conf.ConstructServicesUsing(container.Resolve);
                RegisterProfiles(container, conf);
                container.Register(Component.For<IMapper>().Instance(Mapper.Instance));
            });
            RegisterMappingHelpers(container);
        }

        private void RegisterMappingHelpers(IWindsorContainer container)
        {
            Action<Assembly> action = asm =>
                            container.Register(
                                Classes.FromAssembly(asm).BasedOn(typeof(ITypeConverter<,>)).LifestylePerWebRequest(),
                                Classes.FromAssembly(asm).BasedOn(typeof(IMappingAction<,>)).LifestylePerWebRequest(),
                                Classes.FromAssembly(asm).BasedOn<IValueResolver>().LifestylePerWebRequest());
            action.VisitAssemblies(AssemblyConfiguration);
        }

        private void RegisterProfiles(IWindsorContainer container, IMapperConfiguration conf)
        {
            var childContainer = new WindsorContainer();
            container.AddChildContainer(childContainer);

            Action<Assembly> action = asm =>
                childContainer.Register(Classes.FromAssembly(asm).BasedOn<Profile>().WithServiceBase());
            action.VisitAssemblies(AssemblyConfiguration);

            foreach (var profile in childContainer.ResolveAll<Profile>())
                conf.AddProfile(profile);

            container.RemoveChildContainer(childContainer);
        }
    }
}