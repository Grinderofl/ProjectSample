using ProjectSample.Application.Common.Factories;
using ProjectSample.Application.Common.Services.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Application.Common.Services.Impl
{
    public class CachingCurrentCustomerService : CurrentCustomerService
    {
        private Customer _cachedCustomer;

        public CachingCurrentCustomerService(IRepository repository, IIdentifierFactory<Customer> identifierFactory, ICurrentUserService currentUserService) : base(repository, identifierFactory, currentUserService)
        {
        }

        public override Customer CurrentCustomer() => _cachedCustomer ?? (_cachedCustomer = base.CurrentCustomer());
    }
}