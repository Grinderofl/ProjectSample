using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Application;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.CommandBus;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Basket.Commands.Handlers
{
    public class AddProductToBasketHandler : IHandleCommand<AddProductToBasketCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IRepository _repository;

        public AddProductToBasketHandler(ICurrentUserService currentUserService, IRepository repository)
        {
            _currentUserService = currentUserService;
            _repository = repository;
        }

        public void Handle(AddProductToBasketCommand command)
        {
            var customer = _currentUserService.ActiveCustomer();
            var product = _repository.Find<Product>(command.Id);
            if (product != null)
            {
                customer.AddToBasket(product);
                _repository.Save(customer);
            }
        }
    }
}