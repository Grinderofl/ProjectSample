using System.Collections.Generic;
using System.Linq;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Shipment : Entity<long>
    {
        private readonly ISet<ShipmentItem> _shipmentItems = new HashSet<ShipmentItem>();

        protected Shipment()
        {
        }

        public Shipment(Order order)
        {
            Order = order;
        }


        public virtual IEnumerable<ShipmentItem> ShipmentItems => _shipmentItems;

        public virtual Order Order { get; protected set; }

        public virtual void AddOrUpdateItem(OrderItem orderItem, int quantity = 1)
        {
            var shipmentItem = _shipmentItems.SingleOrDefault(x => x.OrderItem.Product == orderItem.Product);
            if (shipmentItem == null)
            {
                shipmentItem = new ShipmentItem(orderItem, this);
                _shipmentItems.Add(shipmentItem);
            }
            shipmentItem.SetQuantity(quantity);
        }
    }
}