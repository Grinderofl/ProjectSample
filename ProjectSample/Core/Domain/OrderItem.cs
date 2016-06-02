using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class OrderItem : Entity<long>
    {
        protected OrderItem()
        {
        }

        public OrderItem(Order order, Product product)
        {
            Order = order;
            Product = product;
        }

        public virtual Order Order { get; protected set; }

        public virtual Product Product { get; protected set; }

        public virtual int Quantity { get; protected set; }

        public virtual void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}