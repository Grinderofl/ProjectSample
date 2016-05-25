using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Areas.Basket.Commands
{
    public class RemoveProductFromBasketCommand
    {
        public long Id { get; }

        public RemoveProductFromBasketCommand(long id)
        {
            Id = id;
        }
    }
}