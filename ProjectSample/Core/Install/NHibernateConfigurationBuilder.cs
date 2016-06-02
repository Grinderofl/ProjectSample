using Castle.Core.Configuration;
using Castle.Facilities.NHibernateIntegration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ProjectSample.Core.Configuration;

namespace ProjectSample.Core.Install
{
    public class NHibernateConfigurationBuilder : IConfigurationBuilder
    {
        public NHibernate.Cfg.Configuration GetConfiguration(IConfiguration config)
        {
            var conf = Fluently.Configure()
                .ExposeConfiguration(c => c.Properties["default_flush_mode"] = "Commit")
                .Database(
                    () =>
                        MsSqlConfiguration.MsSql2012.ConnectionString(
                            conn => conn.FromConnectionStringWithKey("Default")).ShowSql().DefaultSchema("dbo"))
                .Mappings(
                    m =>
                        m.AutoMappings.Add(
                            AutoMap.AssemblyOf<NHibernateConfigurationBuilder>(
                                new ProjectSampleAutoMappingConfiguration())
                                .UseOverridesFromAssemblyOf<NHibernateConfigurationBuilder>()
                                .AddMappingsFromAssemblyOf<NHibernateConfigurationBuilder>()
                                .Conventions.AddFromAssemblyOf<NHibernateConfigurationBuilder>()
                            )
                );

            return conf.BuildConfiguration();
        }
    }
}