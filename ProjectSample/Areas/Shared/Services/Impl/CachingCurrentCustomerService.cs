using ProjectSample.Areas.Shared.Factories;
using ProjectSample.Areas.Shared.Services.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Shared.Services.Impl
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