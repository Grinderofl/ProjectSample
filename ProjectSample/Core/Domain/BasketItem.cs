using System;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class BasketItem : Entity<long>
    {
        protected BasketItem()
        {

        }

        private BasketItem(Product product, Basket basket)
        {
            Product = product;
            Basket = basket;
        }
        
        public virtual Product Product { get; protected set; }
        // Business requirement: Default quantity of new product in basket is 1
        public virtual int Quantity { get; set; } = 1;
        public virtual Basket Basket { get; protected set; }

        public static BasketItem Create(Product product, Basket basket)
        {
            return new BasketItem(product, basket);
        }

        public virtual void IncreaseQuantity()
        {
            Quantity++;
        }
    }
}