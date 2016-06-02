using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSample.Core.Migrations;

namespace ProjectSample.Areas.Boot.Controllers
{
    public class MigrateController : Controller
    {
        public ActionResult Index()
        {
            var migrator = new MigrationRunner();
            migrator.Execute(GetType(), ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            return View();
        }
    }
}