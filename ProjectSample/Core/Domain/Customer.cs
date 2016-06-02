using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Customer : Entity<long>
    {
        public Customer()
        {
            Basket = new Basket(this);
        }

        public virtual string Identifier { get; set; }

        public virtual Basket Basket { get; protected set; }

        public virtual User User { get; set; }

        public virtual void TransferBasket(Customer other)
        {
            foreach (var item in other.Basket.Items)
            {
                AddToBasket(item.Product, item.Quantity);
            }
        }

        public virtual void AddToBasket(Product product, int quantity = 1)
        {
            Basket.Add(product, quantity);
        }

        public virtual void RemoveFromBasket(Product product)
        {
            Basket.Remove(product);
        }
    }
}