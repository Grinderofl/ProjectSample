using System;
using System.Reflection;
using Castle.Core.Configuration;
using Castle.Facilities.NHibernateIntegration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.Application.Configuration
{
    public class NHibernateConfigurationBuilder : IConfigurationBuilder
    {
        public NHibernate.Cfg.Configuration GetConfiguration(IConfiguration config)
        {
            var assemblyConf = new ProjectSampleAssemblyConfiguration();
            var conf = Fluently.Configure()
                .ExposeConfiguration(c => c.Properties["default_flush_mode"] = "Commit")
                .Database(
                    () =>
                        MsSqlConfiguration.MsSql2012.ConnectionString(
                            conn => conn.FromConnectionStringWithKey("Default")).ShowSql().DefaultSchema("dbo"))
                .Mappings(
                    m =>
                    {
                        var automap = AutoMap.Assemblies(new ProjectSampleAutoMappingConfiguration(), assemblyConf.Assemblies);
                        Action<Assembly> action = asm =>
                            automap
                                .AddMappingsFromAssembly(asm)
                                .UseOverridesFromAssembly(asm)
                                .Conventions.AddAssembly(asm);
                        action.VisitAssemblies(assemblyConf);
                        m.AutoMappings.Add(automap);
                    }
                );

            return conf.BuildConfiguration();
        }
    }
}