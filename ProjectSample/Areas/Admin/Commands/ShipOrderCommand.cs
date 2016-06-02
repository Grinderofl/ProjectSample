using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Admin.Commands
{
    public class ShipOrderCommand
    {
        public ShipOrderCommand(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}