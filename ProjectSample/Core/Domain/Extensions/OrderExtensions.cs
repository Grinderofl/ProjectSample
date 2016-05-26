using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Core.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static bool IsInState(this Order order, OrderState state) => order.CurrentState == state;

        public static bool IsPlaced(this Order order) => order.IsInState(OrderState.Placed);

        public static bool IsAccepted(this Order order) => order.IsInState(OrderState.Accepted);

        public static void Accept(this Order order) => order.Progress(OrderState.Accepted);

        public static void Complete(this Order order) => order.Progress(OrderState.Completed);
    }
}