using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class ShipmentItem : Entity<long>
    {
        protected ShipmentItem()
        {
        }

        public ShipmentItem(OrderItem orderItem, Shipment shipment)
        {
            OrderItem = orderItem;
            Shipment = shipment;
        }

        public virtual Product Product => OrderItem.Product;
        public virtual Order Order => OrderItem.Order;
        public virtual Shipment Shipment { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual OrderItem OrderItem { get; protected set; }

        public virtual void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}