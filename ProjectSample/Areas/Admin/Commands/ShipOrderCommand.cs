using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Admin.Commands
{
    public class ShipOrderCommand
    {
        public Order Order { get; }

        public ShipOrderCommand(Order order)
        {
            Order = order;
        }
    }
}