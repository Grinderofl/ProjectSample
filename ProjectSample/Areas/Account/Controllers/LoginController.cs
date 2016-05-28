using System.Web.Mvc;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Commands.Handlers;
using ProjectSample.Areas.Account.Models.Login;
using ProjectSample.Core.Infrastructure.Identity;

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
                else
                {
                    ModelState.AddModelError("Email", result.Message);
                }
            }
            return View(fields);
        }
    }
}