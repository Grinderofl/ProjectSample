using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Areas.Basket.Models
{
    public class BasketItemModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}