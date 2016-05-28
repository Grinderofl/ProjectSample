using ProjectSample.Core.Domain;

namespace ProjectSample.Core.Application
{
    public interface ICurrentCustomerService
    {
        Customer ActiveCustomer();
    }
}