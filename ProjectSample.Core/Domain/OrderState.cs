using System.Diagnostics;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    [DebuggerDisplay("{DebuggerDisplay(),nq}")]
    public class OrderState : Entity<short>
    {
        public static OrderState Placed = new OrderState(1, "Placed");
        public static OrderState Accepted = new OrderState(2, "Accepted");
        public static OrderState Completed = new OrderState(3, "Completed");

        protected OrderState()
        {
        }

        private OrderState(short id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual string Name { get; set; }

        public virtual string DebuggerDisplay()
        {
            return $"{Name}({Id})";
        }
    }
}