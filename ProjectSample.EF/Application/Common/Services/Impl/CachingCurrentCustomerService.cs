using System.Data.Entity;
using ProjectSample.EF.Application.Common.Factories;
using ProjectSample.EF.Application.Common.Services.Impl.Base;
using ProjectSample.EF.Core.Domain;

namespace ProjectSample.EF.Application.Common.Services.Impl
{
    public class CachingCurrentCustomerService : CurrentCustomerService
    {
        private Customer _cachedCustomer;

        public CachingCurrentCustomerService(IIdentifierFactory<Customer> identifierFactory, DbContext context) : base(identifierFactory, context)
        {
        }

        public override Customer CurrentCustomer() => _cachedCustomer ?? (_cachedCustomer = base.CurrentCustomer());
    }
}