using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Visitors;
using ProjectSample.Core.Application;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.CommandBus;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Basket.Commands.Handlers
{
    public class AddProductToBasketHandler : IHandleCommand<AddProductToBasketCommand>
    {
        private readonly ICurrentCustomerService _currentCustomerService;
        private readonly IRepository _repository;

        public AddProductToBasketHandler(ICurrentCustomerService currentCustomerService, IRepository repository)
        {
            _currentCustomerService = currentCustomerService;
            _repository = repository;
        }

        public void Handle(AddProductToBasketCommand command)
        {
            var customer = _currentCustomerService.CurrentCustomer();
            var product = _repository.Find<Product>(command.Id);
            if (product != null)
            {
                customer.AddToBasket(product);
                _repository.Save(customer);
            }
        }
    }
}