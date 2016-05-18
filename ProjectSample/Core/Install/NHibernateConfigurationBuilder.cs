using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.Core.Configuration;
using Castle.Facilities.NHibernateIntegration;
using Castle.Facilities.NHibernateIntegration.Builders;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using NHibernate.Cfg;

namespace ProjectSample.Core.Install
{
    public class NHibernateConfigurationBuilder : IConfigurationBuilder
    {
        public Configuration GetConfiguration(IConfiguration config)
        {
            var conf = Fluently.Configure()
                .ExposeConfiguration(c => c.Properties["default_flush_mode"] = "Commit")
                .Database(
                    () =>
                        MsSqlConfiguration.MsSql2012.ConnectionString(
                            "Data Source=.;Initial Catalog=NHTest;Integrated Security=SSPI;").ShowSql().DefaultSchema("dbo"))
                .Mappings(
                    m => m.AutoMappings.Add(AutoMap.AssemblyOf<NHibernateConfigurationBuilder>(new NhTestAutoMappingConfiguration())
                        .UseOverridesFromAssemblyOf<NHibernateConfigurationBuilder>()
                        .AddMappingsFromAssemblyOf<NHibernateConfigurationBuilder>()
                        )
                );

            return conf.BuildConfiguration();
        }
    }
}