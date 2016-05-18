using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;

namespace ProjectSample.Core.Migrations
{
    public class MigrationRunner
    {
        public void Execute(Type type, string connectionString)
        {
            var announcer = new TextWriterAnnouncer(s => Console.WriteLine(s));
            var assembly = Assembly.GetAssembly(type);

            var migrationContext = new RunnerContext(announcer);

            var options = new ProcessorOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new SqlServer2008ProcessorFactory();
            var processor = factory.Create(connectionString, announcer, options);
            var runner = new FluentMigrator.Runner.MigrationRunner(assembly, migrationContext, processor);
            runner.MigrateUp(true);
        }
    }
}