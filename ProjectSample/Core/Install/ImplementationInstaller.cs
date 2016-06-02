using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ProjectSample.Core.Install
{
    public class ImplementationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .Where(t => t.Namespace != null && t.Namespace.EndsWith(".Impl"))
                    .LifestylePerWebRequest()
                    .WithServiceFirstInterface());
        }
    }
}