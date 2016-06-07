using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Account.Commands.Handlers
{
    public class TransferBasketHandler : IHandleCommand<TransferBasketCommand>
    {
        private IRepository _repository;

        public TransferBasketHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(TransferBasketCommand command)
        {
            var userCustomer = command.User.Customer;
            userCustomer.TransferBasket(command.TransferFrom);
            _repository.Save(userCustomer);
        }
    }
}