using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Order : Entity<long>
    {
        protected Order()
        { }
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
            var currentItem = _orderItems.SingleOrDefault(p => p.Product == product);
            if (currentItem == null)
            {
                currentItem = new OrderItem(this, product);
                _orderItems.Add(currentItem);
            }
            currentItem.SetQuantity(quantity);
        }

        public virtual Shipment CreateShipment()
        {
            var shipment = new Shipment(this);
            _shipments.Add(shipment);
            return shipment;
        }

        public virtual IEnumerable<Shipment> Shipments => _shipments; 

        private readonly ISet<Shipment> _shipments = new HashSet<Shipment>(); 

        public virtual OrderState CurrentState { get; protected set; }

        private readonly ISet<OrderStateHistoryItem> _orderStateHistory = new HashSet<OrderStateHistoryItem>();
        public virtual IEnumerable<OrderStateHistoryItem> OrderStateHistory => _orderStateHistory;
        
        private readonly ISet<OrderItem> _orderItems = new HashSet<OrderItem>();

        public virtual IEnumerable<OrderItem> OrderItems => _orderItems;
        public virtual DateTime Created { get; set; } = DateTime.Now;
    }
}