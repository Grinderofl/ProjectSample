using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Core.Infrastructure.Identity;

namespace ProjectSample.Areas.Account.Controllers
{
    public class LogoutController : AccountControllerBase
    {
        public ActionResult Index()
        {
            Bus.Send(new LogoutUserCommand());
            return RedirectToAction("Index", "Home", new { @area = "Home" });
        }
    }
}