using System;
using ProjectSample.Core.Infrastructure.CommandBus;
using ProjectSample.Core.Infrastructure.Identity;

namespace ProjectSample.Areas.Account.Commands.Handlers
{
    public class LogoutUserHandler : IHandleCommand<LoginUserCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public LogoutUserHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void Handle(LoginUserCommand command)
        {
            _authorizationService.SignOut();
        }
    }
}