using System.Collections.Generic;
using System.Linq;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Basket : Entity<long>
    {
        private readonly ISet<BasketItem> _items = new HashSet<BasketItem>();

        protected Basket()
        { }

        public Basket(Customer customer)
        {
            Customer = customer;
        }

        public virtual IEnumerable<BasketItem> Items => _items ;
        public virtual Customer Customer { get; protected set; }

        public virtual void Add(Product product, int quantity)
        {
            var currentItem = FindItemForProduct(product);
            if (currentItem == null)
            {
                currentItem = BasketItem.Create(product, this);
                _items.Add(currentItem);
            }
            else
            {
                currentItem.IncreaseQuantity(quantity);
            }
        }

        public virtual void Remove(Product product, int quantity = 0)
        {
            var currentItem = FindItemForProduct(product);
            if (currentItem != null)
            {
                if (quantity > 0)
                {
                    currentItem.DecreaseQuantity(quantity);
                }
                else
                {
                    _items.Remove(currentItem);
                }
            }
        }

        public virtual BasketItem FindItemForProduct(Product product)
            => _items.SingleOrDefault(x => x.Product == product);

        public virtual void Empty() => _items.Clear();
    }
}