using System.Collections.Generic;
using System.Linq;
using ProjectSample.EF.Infrastructure.Domain.Base;

namespace ProjectSample.EF.Core.Domain
{
    public class Basket : Entity<long>
    {
        public virtual Customer Customer { get; protected set; }
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();

        public virtual void Add(Product product, int quantity)
        {
            var currentItem = FindItemForProduct(product);
            if (currentItem == null)
            {
                currentItem = BasketItem.Create(product, this);
                if (quantity > 0)
                    currentItem.IncreaseQuantity(quantity - 1);
                Items.Add(currentItem);
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
                    Items.Remove(currentItem);
                }
            }
        }

        public virtual BasketItem FindItemForProduct(Product product)
            => Items.SingleOrDefault(x => x.Product == product);

        public virtual void Empty() => Items.Clear();
    }
}