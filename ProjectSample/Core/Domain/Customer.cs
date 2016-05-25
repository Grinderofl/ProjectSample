using System.Collections.Generic;
using System.Linq;
using ProjectSample.Core.Domain.Base;

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

        public virtual void AddToBasket(Product product)
        {
            Basket.Add(product);
        }
    }
}