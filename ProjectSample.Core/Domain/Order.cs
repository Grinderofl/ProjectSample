using System;
using System.Collections.Generic;
using System.Linq;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Order : Entity<long>
    {
        private readonly ISet<OrderItem> _items = new HashSet<OrderItem>();

        private readonly ISet<OrderStateHistoryItem> _orderStateHistory = new HashSet<OrderStateHistoryItem>();

        private readonly ISet<Shipment> _shipments = new HashSet<Shipment>();

        protected Order()
        { }

        public virtual IEnumerable<Shipment> Shipments => _shipments;

        public virtual OrderState CurrentState { get; protected set; }
        public virtual IEnumerable<OrderStateHistoryItem> OrderStateHistory => _orderStateHistory;

        public virtual IEnumerable<OrderItem> Items => _items;
        public virtual DateTime Created { get; set; } = DateTime.Now;

        public static Order Create()
        {
            var order = new Order();
            order.Progress(OrderState.Placed);
            return order;
        }

        public virtual void Progress(OrderState state)
        {
            if (_orderStateHistory.All(c => c.State != state))
            {
                _orderStateHistory.Add(new OrderStateHistoryItem(this, state));
                CurrentState = state;
            }
        }

        public virtual void AddOrUpdateProduct(Product product, int quantity = 1)
        {
            var currentItem = _items.SingleOrDefault(p => p.Product == product);
            if (currentItem == null)
            {
                currentItem = new OrderItem(this, product);
                _items.Add(currentItem);
            }
            currentItem.SetQuantity(quantity);
        }

        public virtual Shipment CreateShipment()
        {
            var shipment = new Shipment(this);
            _shipments.Add(shipment);
            return shipment;
        }
    }
}