using System.Web.Mvc;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Models.Register;
using ProjectSample.Areas.Account.Services;

namespace ProjectSample.Areas.Account.Controllers
{
    public class RegisterController : AccountControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegisterController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterFields fields)
        {
            if (ModelState.IsValid)
            {
                var result = _registrationService.Register(fields);
                if (result.Registered)
                {
                    Bus.Send(new LoginUserCommand(result.User));
                    return RedirectToAction("Index", "Home", new {area = "Catalog"});
                }
                ModelState.AddModelError("Email", result.Message);
            }
            return View(fields);
        }
    }
}