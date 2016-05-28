using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSample.Areas.Account.Models.Login;
using ProjectSample.Areas.Account.Models.Register;
using ProjectSample.Areas.Account.Services;
using ProjectSample.Core.Infrastructure.Identity;

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
                    return RedirectToAction("Index", "Login", new {fields.Email, fields.Password});
                }
            }
            return View(fields);
        }
    }

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
                    
                }
            }
            return View(fields);
        }
    }
}