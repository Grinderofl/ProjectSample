using System.Configuration;
using System.Web.Mvc;
using Castle.Core.Internal;
using NHibernate.FluentMigrator;
using NHibernate.Tool.hbm2ddl;
using ProjectSample.Application.Configuration;
using ProjectSample.Areas.Boot.Services.Impl;
using ProjectSample.Core.Migrations;

namespace ProjectSample.Areas.Boot.Controllers
{
    public class MigrationsController : Controller
    {
        private readonly MigrationService _migrationService;

        public MigrationsController()
        {
            _migrationService = new MigrationService(this);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PerformMigration()
        {
            _migrationService.PerformMigration();
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
            _migrationService.CreateMigration(id);
            return Content("Done");
        }
    }
}