using System.Configuration;
using System.Web;
using NHibernate.FluentMigrator;
using NHibernate.Tool.hbm2ddl;
using ProjectSample.Application.Configuration;
using ProjectSample.Areas.Boot.Controllers;
using ProjectSample.Core.Migrations;

namespace ProjectSample.Areas.Boot.Services.Impl
{
    public class MigrationService : IMigrationService
    {
        private readonly MigrationsController _migrationsController;

        public MigrationService(MigrationsController migrationsController)
        {
            _migrationsController = migrationsController;
        }

        public void CreateMigration(string id)
        {
            var configuration = new NHibernateConfigurationBuilder().GetConfiguration(null);
            var sqlFilename = HttpContext.Current.Server.MapPath($"~/Sql/{id}.sql");
            System.IO.File.Delete(sqlFilename);
            new SchemaUpdate(configuration).Execute(s => System.IO.File.AppendAllText(sqlFilename, s), false);
            var generator = new SchemaGenerator(configuration);
            new SchemaClassGenerator(generator).SaveClassFile(_migrationsController.Server.MapPath("~/Sql/"), id, "ProjectSample.Core.Migrations");
        }

        public void PerformMigration()
        {
            var migrator = new MigrationRunner();
            migrator.Execute(typeof(MigrationRunner), ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }
    }
}