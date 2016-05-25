using ProjectSample.Core.Application.Models;

namespace ProjectSample.Core.Application
{
    public interface ICustomerIdentityFactory
    {
        CustomerIdentity CreateIdentity();
    }
}