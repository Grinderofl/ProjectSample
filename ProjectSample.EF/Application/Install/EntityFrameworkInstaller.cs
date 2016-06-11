using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectSample.EF.Application.Install.Base;
using ProjectSample.EF.Infrastructure.Domain.Base;
using ProjectSample.EF.Models;

namespace ProjectSample.EF.Application.Install
{
    public class EntityFrameworkInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var contributor = new ModelBuilderContributor(AssemblyConfiguration.Assemblies);
            container.Register(
                Component.For<DbContext>().ImplementedBy<ApplicationDbContext>().LifestylePerWebRequest(),
                Component.For<ModelBuilderContributor>().Instance(contributor), 
                Component.For<ConnectionStringSource>());


        }
    }

    public class ConnectionStringSource
    {
        public virtual string GetConnectionStringName()
        {
            return "DefaultConnection";
        }
    }

    public class ModelBuilderContributor
    {
        private readonly Assembly[] _assemblies;

        public ModelBuilderContributor(Assembly[] assemblies)
        {
            this._assemblies = assemblies;
        }

        public virtual void Contribute(DbModelBuilder modelBuilder)
        {
            foreach (var assembly in _assemblies)
            {
                modelBuilder.Conventions.AddFromAssembly(assembly);
                modelBuilder.Configurations.AddFromAssembly(assembly);
            }


            foreach (
                var type in _assemblies.SelectMany(a => a.GetExportedTypes()).Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(Entity)))
                )
            {
                modelBuilder.RegisterEntityType(type);
            }
        }
    }
}