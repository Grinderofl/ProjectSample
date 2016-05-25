using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Areas.Basket.Commands
{
    public class AddProductToBasketCommand
    {
        public long Id { get; }

        public AddProductToBasketCommand(long id)
        {
            Id = id;
        }
    }
}