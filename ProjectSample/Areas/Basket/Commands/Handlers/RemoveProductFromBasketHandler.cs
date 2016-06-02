using System.Linq;
using ProjectSample.Areas.Basket.Factories;
using ProjectSample.Areas.Shared.Services;
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

    public class CheckoutHandler : IHandleCommand<CheckoutCommand>
    {
        private readonly IOrderFactory _orderFactory;
        private readonly IRepository _repository;

        public CheckoutHandler(IRepository repository, IOrderFactory orderFactory)
        {
            _repository = repository;
            _orderFactory = orderFactory;
        }

        public void Handle(CheckoutCommand command)
        {
            var customer = command.Customer;
            if (!customer.Basket.Items.Any()) return;
            var order = _orderFactory.Create(customer.Basket);
            if (order != null)
                _repository.Save(order);
            customer.Basket.Empty();
            _repository.Save(customer);
        }
    }
}