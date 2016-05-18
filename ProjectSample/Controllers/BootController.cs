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
            new SchemaUpdate(configuration).Execute(s => System.IO.File.AppendAllText(Server.MapPath($"~/Sql/{id}.sql"), s), false);
            //new SchemaExport(configuration).Execute(s => System.IO.File.AppendAllText(Server.MapPath("~/Sql/create.sql"), s), false, false, Response.Output);
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