using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectSample.EF.Application.Configuration;
using ProjectSample.EF.Application.Install;
using ProjectSample.EF.Core.Domain;

namespace ProjectSample.EF.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly ModelBuilderContributor _contributor;

        public ApplicationDbContext(ConnectionStringSource connectionStringSource, ModelBuilderContributor contributor)
            : base(connectionStringSource.GetConnectionStringName(), throwIfV1Schema: false)
        {
            _contributor = contributor;
        }

        public ApplicationDbContext() : this(new ConnectionStringSource(), new ModelBuilderContributor(new ProjectSampleAssemblyConfiguration().Assemblies))
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _contributor.Contribute(modelBuilder);
        }
    }
}