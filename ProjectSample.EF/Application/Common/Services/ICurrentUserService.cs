using ProjectSample.EF.Core.Domain;

namespace ProjectSample.EF.Application.Common.Services
{
    public interface ICurrentCustomerService
    {
        Customer CurrentCustomer();
    }
}