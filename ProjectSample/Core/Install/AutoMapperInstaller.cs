using System;
using System.Reflection;
using AutoMapper;
using Castle.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Core.Install.Base;
using ProjectSample.Infrastructure.Windsor;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Core.Install
{
    public class AutoMapperInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {

            
            Mapper.Initialize(conf =>
            {
                conf.ConstructServicesUsing(container.Resolve);
                var childContainer = new WindsorContainer();
                container.AddChildContainer(childContainer);
                Action<Assembly> action = asm =>
                    childContainer.Register(Classes.FromAssembly(asm).BasedOn<Profile>().WithServiceBase());
                action.VisitAssemblies(AssemblyConfiguration);
                foreach (var profile in childContainer.ResolveAll<Profile>())
                    conf.AddProfile(profile);
                container.RemoveChildContainer(childContainer);
                container.Register(Component.For<IMapper>().Instance(Mapper.Instance));
            });

            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof (ITypeConverter<,>)),
                Classes.FromThisAssembly().BasedOn(typeof (IMappingAction<,>)),
                Classes.FromThisAssembly().BasedOn<IValueResolver>());
        }
    }
}