using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Basket.Commands
{
    public class CheckoutCommand
    {
        public CheckoutCommand(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; }
    }
}