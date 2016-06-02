using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Services;

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