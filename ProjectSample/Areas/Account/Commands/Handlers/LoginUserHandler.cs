using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Services;

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