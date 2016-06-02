using ProjectSample.Areas.Shared.Factories;
using ProjectSample.Areas.Shared.Services.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Shared.Services.Impl
{
    public class CachingCurrentCustomerService : CurrentCustomerService
    {
        public CachingCurrentCustomerService(IRepository repository, IIdentifierFactory<Customer> identifierFactory, ICurrentUserService currentUserService) : base(repository, identifierFactory, currentUserService)
        {
        }

        private Customer _cachedCustomer;

        public override Customer CurrentCustomer() => _cachedCustomer ?? (_cachedCustomer = base.CurrentCustomer());
    }
}