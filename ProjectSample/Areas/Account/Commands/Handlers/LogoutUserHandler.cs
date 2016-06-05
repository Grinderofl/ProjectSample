using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Services;

namespace ProjectSample.Areas.Account.Commands.Handlers
{
    public class LogoutUserHandler : IHandleCommand<LogoutUserCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public LogoutUserHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void Handle(LogoutUserCommand command)
        {
            _authorizationService.SignOut();
        }
    }
}