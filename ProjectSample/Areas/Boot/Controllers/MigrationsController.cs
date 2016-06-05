using System.Configuration;
using System.Web.Mvc;
using Castle.Core.Internal;
using NHibernate.FluentMigrator;
using NHibernate.Tool.hbm2ddl;
using ProjectSample.Core.Configuration;
using ProjectSample.Core.Install;
using ProjectSample.Core.Migrations;

namespace ProjectSample.Areas.Boot.Controllers
{
    public class MigrationsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PerformMigration()
        {
            var migrator = new MigrationRunner();
            migrator.Execute(GetType(), ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(string id)
        {
            if (id.IsNullOrEmpty())
                return Content("No name");
            var configuration = new NHibernateConfigurationBuilder().GetConfiguration(null);
            var sqlFilename = Server.MapPath($"~/Sql/{id}.sql");
            System.IO.File.Delete(sqlFilename);
            new SchemaUpdate(configuration).Execute(s => System.IO.File.AppendAllText(sqlFilename, s), false);
            var generator = new SchemaGenerator(configuration);
            new SchemaClassGenerator(generator).SaveClassFile(Server.MapPath("~/Sql/"), id, "ProjectSample.Core.Migrations");
            return Content("Done");
        }
    }
}