using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using Castle.Facilities.NHibernateIntegration;
using NHibernate.FluentMigrator;
using NHibernate.Tool.hbm2ddl;
using ProjectSample.Core.Install;
using ProjectSample.Core.Migrations;

namespace ProjectSample.Controllers
{
    public class BootController : Controller
    {
        

        public ActionResult Index(string id)
        {
            if (id.IsNullOrEmpty())
                return Content("No name");
            var configuration = new NHibernateConfigurationBuilder().GetConfiguration(null);
            var sqlFilename = Server.MapPath($"~/Sql/{id}.sql");
            System.IO.File.Delete(sqlFilename);
            new SchemaUpdate(configuration).Execute(s => System.IO.File.AppendAllText(sqlFilename, s), false);
            var generator = new SchemaGenerator(configuration);
            new SchemaClassGenerator(generator).SaveClassFile(Server.MapPath("~/Sql/"), id, "ProjectSample.Migrations");
            return Content("Done");
        }

        public ActionResult Migrate()
        {
            var migrator = new MigrationRunner();
            migrator.Execute(typeof(BootController), "Data Source=.;Initial Catalog=NHTest;Integrated Security=SSPI;");
            return Content("Done");
        }
    }
}