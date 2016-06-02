using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Shared.Services
{
    public interface ICurrentCustomerService
    {
        Customer CurrentCustomer();
    }
}