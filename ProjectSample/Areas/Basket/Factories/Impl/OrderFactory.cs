using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Basket.Factories.Impl
{
    public class OrderFactory : IOrderFactory
    {
        public Order Create(Core.Domain.Basket basket)
        {
            var order = Order.Create();
            foreach (var item in basket.Items)
            {
                order.AddOrUpdateProduct(item.Product, item.Quantity);
            }
            return order;
        }
    }
}