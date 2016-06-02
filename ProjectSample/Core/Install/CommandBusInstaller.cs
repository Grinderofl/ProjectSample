using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Infrastructure.CommandBus;

namespace ProjectSample.Core.Install
{
    public class CommandBusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICommandHandlerFactory>().AsFactory().LifestylePerWebRequest());
            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof (IHandleCommand<>)).WithServiceBase().LifestyleTransient());

        }
    }
}