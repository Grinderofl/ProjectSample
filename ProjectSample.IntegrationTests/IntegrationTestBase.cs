using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using ProjectSample.Application.Configuration;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.NHibernate.DataAccess.Impl;
using ProjectSample.Infrastructure.Security.Domain;
using ProjectSample.Infrastructure.Windsor.Extensions;
using ProjectSample.UnitTests;
using Environment = NHibernate.Cfg.Environment;

namespace ProjectSample.IntegrationTests
{
    public class IntegrationTestBase : TestBase, IDisposable
    {
        private Configuration _configuration;

        protected ISession Session;
        protected IRepository Repository;

        public override void OneTimeSetup()
        {
            InitializeIntegrationTest();
            SaveAll(new[] {Role.User, Role.Administrator});
            base.OneTimeSetup();
        }

        protected virtual void InitializeIntegrationTest()
        {
            if (_configuration == null)
            {
                var assemblyConf = new ProjectSampleAssemblyConfiguration();
                var conf = Fluently.Configure()
                    .ExposeConfiguration(c =>
                    {
                        c.Properties["default_flush_mode"] = "Commit";
                        c.SetProperty(Environment.ReleaseConnections, "on_close");
                        c.SetProperty(Environment.ProxyFactoryFactoryClass,typeof(DefaultProxyFactoryFactory).AssemblyQualifiedName);
                    })
                    .Database(
                        () =>
                            SQLiteConfiguration.Standard
                            .Dialect<SQLiteDialect>()
                            .Driver(typeof(SQLite20Driver).AssemblyQualifiedName)
                            .ShowSql()
                            .FormatSql()
                            .InMemory()
                            )
                    .Mappings(
                        m =>
                        {
                            var automap = AutoMap.Assemblies(new ProjectSampleAutoMappingConfiguration(),
                                assemblyConf.Assemblies);
                            Action<Assembly> action = asm =>
                                automap
                                    .AddMappingsFromAssembly(asm)
                                    .UseOverridesFromAssembly(asm)
                                    .Conventions.AddAssembly(asm);
                            action.VisitAssemblies(assemblyConf);
                            m.AutoMappings.Add(automap);
                        }
                    );

                _configuration = conf.BuildConfiguration();
                var sessionFactory = _configuration.BuildSessionFactory();
                Session = sessionFactory.OpenSession();
                Repository = new NhRepository(new StackBasedUnitOfWork(Session), Session);
                new SchemaExport(_configuration).Execute(true, true, false, Session.Connection, Console.Out);
            }
        }

        protected virtual void Save<T>(T entity)
        {
            using (var tx = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                tx.Commit();
            }
        }

        protected virtual void SaveAll<T>(IEnumerable<T> entities)
        {
            using (var tx = Session.BeginTransaction())
            {
                foreach (var entity in entities)
                    Session.Save(entity);
                tx.Commit();
            }
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
