using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.Core.Infrastructure.DataAccess.List;
using ProjectSample.Core.Infrastructure.NHibernate.DataAccess.List.Impl;

namespace ProjectSample.Core.Install
{
    public class ListServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(
            //    Component.For(typeof (IListService<>)).ImplementedBy(typeof (NhListService<>)).LifestylePerWebRequest());
        }
    }
}