using System.Data.Entity;
using ProjectSample.EF.Application.Common.Factories;
using ProjectSample.EF.Core.Domain;
using ProjectSample.EF.Core.Domain.Queries;

namespace ProjectSample.EF.Application.Common.Services.Impl.Base
{
    public class CurrentCustomerService : ICurrentCustomerService
    {
        private readonly IIdentifierFactory<Customer> _identifierFactory;
        private readonly DbContext _context;

        public CurrentCustomerService(IIdentifierFactory<Customer> identifierFactory, DbContext context)
        {
            _identifierFactory = identifierFactory; 
            _context = context;
        }

        public virtual Customer CurrentCustomer()
        {
            var identifier = _identifierFactory.CreateIdentifier();
            var customer = new FindCustomerByIdentityQuery(identifier).Execute(_context);
            if (customer == null)
            {
                customer = new Customer
                {
                    Identifier = identifier
                };
                _context.Set<Customer>().Add(customer);
                _context.SaveChanges();
            }
            return customer;
        }
    }
}