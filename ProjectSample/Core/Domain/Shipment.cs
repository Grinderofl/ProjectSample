using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;
using ProjectSample.Core.Domain.Mapping;

namespace ProjectSample.Core.Domain
{
    public class Shipment : Entity<long>
    {
        protected Shipment()
        {
            
        }

        public Shipment(Order order)
        {
            Order = order;
        }

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


        public virtual IEnumerable<ShipmentItem> ShipmentItems => _shipmentItems;

        private readonly ISet<ShipmentItem> _shipmentItems = new HashSet<ShipmentItem>();
        
        public virtual Order Order { get; protected set; }

    }
}