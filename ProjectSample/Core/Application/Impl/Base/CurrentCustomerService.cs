using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Queries;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Application.Impl.Base
{
    public class CurrentCustomerService : ICurrentCustomerService
    {
        private readonly IRepository _repository;
        private readonly IIdentifierFactory<Customer> _identifierFactory;
        private readonly ICurrentUserService _currentUserService;

        public CurrentCustomerService(IRepository repository, IIdentifierFactory<Customer> identifierFactory, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _identifierFactory = identifierFactory;
            _currentUserService = currentUserService;
        }

        public virtual Customer CurrentCustomer()
        {
            var currentUser = _currentUserService.CurrentUser();
            if (currentUser != null)
                return currentUser.Customer;

            var identifier = _identifierFactory.CreateIdentifier();
            var customer = _repository.Query(new FindCustomerByIdentityQuery(identifier));
            if (customer == null)
            {
                customer = new Customer()
                {
                    Identifier = identifier
                };
                _repository.Save(customer);
            }
            return customer;
        }
    }
}