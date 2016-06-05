using System;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class OrderStateHistoryItem : Entity<long>
    {
        protected OrderStateHistoryItem()
        {
            
        }

        public OrderStateHistoryItem(Order order, OrderState state)
        {
            Order = order;
            State = state;
        }

        public virtual Order Order { get; set; }
        public virtual OrderState State { get; set; }
        public virtual DateTime Created { get; set; } = DateTime.Now;
    }
}