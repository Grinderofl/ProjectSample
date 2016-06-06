using System.Web.Mvc;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Models.Login;
using ProjectSample.Infrastructure.Security.Services;

namespace ProjectSample.Areas.Account.Controllers
{
    public class LoginController : AccountControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginFields fields)
        {
            if (ModelState.IsValid)
            {
                var result = _authenticationService.Authenticate(fields.Email, fields.Password);
                if (result.Authenticated)
                {
                    Bus.Send(new LoginUserCommand(result.User));
                    return RedirectToAction("Index", "Home", new {area = "Catalog"});
                }
                ModelState.AddModelError(nameof(fields.Email), result.Message);
            }
            return View(fields);
        }
    }
}