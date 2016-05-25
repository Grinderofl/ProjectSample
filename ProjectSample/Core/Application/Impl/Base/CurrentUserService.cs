using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Queries;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Application.Impl.Base
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IRepository _repository;
        private readonly ICustomerIdentityFactory _identityFactory;

        public CurrentUserService(IRepository repository, ICustomerIdentityFactory identityFactory)
        {
            _repository = repository;
            _identityFactory = identityFactory;
        }

        public virtual Customer ActiveCustomer()
        {
            var identity = _identityFactory.CreateIdentity();
            var customer = _repository.Query(new FindCustomerByIdentityQuery(identity));
            if (customer == null)
            {
                customer = new Customer()
                {
                    Identifier = identity
                };
                _repository.Save(customer);
            }
            return customer;
        }
    }
}