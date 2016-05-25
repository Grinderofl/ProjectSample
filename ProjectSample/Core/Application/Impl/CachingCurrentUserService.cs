using ProjectSample.Core.Application.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Application.Impl
{
    public class CachingCurrentUserService : CurrentUserService
    {
        public CachingCurrentUserService(IRepository repository, ICustomerIdentityFactory identityFactory) : base(repository, identityFactory)
        {
        }

        private Customer _cachedCustomer;

        public override Customer ActiveCustomer() => _cachedCustomer ?? (_cachedCustomer = base.ActiveCustomer());
    }
}