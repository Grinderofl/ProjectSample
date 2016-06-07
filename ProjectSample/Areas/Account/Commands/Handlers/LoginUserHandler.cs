using ProjectSample.Application.Common.Services;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Services;

namespace ProjectSample.Areas.Account.Commands.Handlers
{
    public class LoginUserHandler : IHandleCommand<LoginUserCommand>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentCustomerService _currentCustomerService;
        private readonly ICommandBus _commandBus;

        public LoginUserHandler(IAuthorizationService authorizationService, ICurrentCustomerService currentCustomerService, ICommandBus commandBus)
        {
            _authorizationService = authorizationService;
            _currentCustomerService = currentCustomerService;
            _commandBus = commandBus;
        }

        public void Handle(LoginUserCommand command)
        {
            var activeCustomer = _currentCustomerService.CurrentCustomer();
            _authorizationService.SignIn(command.User);
            _commandBus.Send(new TransferBasketCommand(command.User, activeCustomer));
        }
    }
}