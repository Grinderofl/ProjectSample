using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Infrastructure.CommandBus;
using ProjectSample.Core.Infrastructure.Identity;

namespace ProjectSample.Areas.Account.Commands.Handlers
{
    public class LoginUserHandler : IHandleCommand<LoginUserCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public LoginUserHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void Handle(LoginUserCommand command)
        {
            _authorizationService.SignIn(command.User);
        }
    }
}