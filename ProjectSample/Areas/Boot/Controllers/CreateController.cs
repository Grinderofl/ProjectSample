using System.Web.Mvc;
using Castle.Core.Internal;
using NHibernate.FluentMigrator;
using NHibernate.Tool.hbm2ddl;
using ProjectSample.Core.Install;

namespace ProjectSample.Areas.Boot.Controllers
{
    public class CreateController : Controller
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
            new SchemaClassGenerator(generator).SaveClassFile(Server.MapPath("~/Sql/"), id, "ProjectSample.Core.Migrations");
            return Content("Done");
        }
    }
}