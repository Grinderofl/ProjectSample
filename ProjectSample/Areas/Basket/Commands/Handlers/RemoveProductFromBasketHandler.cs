using ProjectSample.Application.Common.Services;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Basket.Commands.Handlers
{
    public class RemoveProductFromBasketHandler : IHandleCommand<RemoveProductFromBasketCommand>
    {
        private readonly ICurrentCustomerService _currentCustomerService;
        private readonly IRepository _repository;

        public RemoveProductFromBasketHandler(ICurrentCustomerService currentCustomerService, IRepository repository)
        {
            _currentCustomerService = currentCustomerService;
            _repository = repository;
        }

        public void Handle(RemoveProductFromBasketCommand command)
        {
            var customer = _currentCustomerService.CurrentCustomer();
            var product = _repository.Find<Product>(command.Id);
            if (product != null)
            {
                customer.RemoveFromBasket(product);
                _repository.Save(customer);
            }
        }
    }
}