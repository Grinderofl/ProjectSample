using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using ProjectSample.Application.Configuration;

namespace ProjectSample.Application.Install
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var conf = new NHibernateConfigurationBuilder().GetConfiguration(null);
            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(_ => conf.BuildSessionFactory()),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest());
        }
    }
}