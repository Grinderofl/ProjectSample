using System;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ProjectSample.Infrastructure.Windsor
{
    public abstract class AbstractAssemblyInstaller<TConfiguration> : IWindsorInstaller where TConfiguration : AssemblyConfiguration, new()
    {
        protected AssemblyConfiguration AssemblyConfiguration = new TConfiguration();

        public abstract void Install(IWindsorContainer container, IConfigurationStore store);
    }
}