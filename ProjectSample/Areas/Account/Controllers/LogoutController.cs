using System.Web.Mvc;
using ProjectSample.Areas.Account.Commands;

namespace ProjectSample.Areas.Account.Controllers
{
    public class LogoutController : AccountControllerBase
    {
        public ActionResult Index()
        {
            Bus.Send(new LogoutUserCommand());
            return RedirectToAction("Index", "Home", new { area = "Home" });
        }
    }
}