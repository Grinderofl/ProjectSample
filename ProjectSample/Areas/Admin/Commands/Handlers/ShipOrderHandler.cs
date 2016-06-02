using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Extensions;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Admin.Commands.Handlers
{
    public class ShipOrderHandler : IHandleCommand<ShipOrderCommand>
    {
        private readonly IRepository _repository;

        public ShipOrderHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ShipOrderCommand command)
        {
            var order = command.Order;
            if (order.IsAccepted())
            {
                var shipment = order.CreateShipment();
                foreach (var item in order.Items)
                {
                    shipment.AddOrUpdateItem(item, item.Quantity);
                }
                order.Complete();
                _repository.Save(order);
            }
        }
    }
}