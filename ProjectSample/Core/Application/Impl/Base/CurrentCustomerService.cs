using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Queries;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Application.Impl.Base
{
    public class CurrentCustomerService : ICurrentCustomerService
    {
        private readonly IRepository _repository;
        private readonly IIdentifierFactory<Customer> _identifierFactory;

        public CurrentCustomerService(IRepository repository, IIdentifierFactory<Customer> identifierFactory)
        {
            _repository = repository;
            _identifierFactory = identifierFactory;
        }

        public virtual Customer ActiveCustomer()
        {
            var identity = _identifierFactory.CreateIdentifier();
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

        public class CurrentUserService : ICurrentUserService
        {
            public User CurrentUser()
            {
                
            }
        }
    }
}