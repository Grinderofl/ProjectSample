using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Basket : Entity<long>
    {
        protected Basket()
        { }
        public Basket(Customer customer)
        {
            Customer = customer;
        }

        private readonly ISet<BasketItem> _items = new HashSet<BasketItem>();
        public virtual IEnumerable<BasketItem> Items => _items ;
        public virtual Customer Customer { get; protected set; }

        public virtual void Add(Product product)
        {
            var currentItem = FindItemForProduct(product);
            if (currentItem == null)
            {
                currentItem = BasketItem.Create(product, this);
                _items.Add(currentItem);
            }
            else
            {
                currentItem.IncreaseQuantity();
            }
        }

        public virtual void Remove(Product product)
        {
            var currentItem = FindItemForProduct(product);
            if (currentItem != null)
            {
                if (currentItem.Quantity > 1)
                {
                    currentItem.DecreaseQuantity();
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