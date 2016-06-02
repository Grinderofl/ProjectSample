using System.Web.Mvc;

namespace ProjectSample.Areas.Boot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}