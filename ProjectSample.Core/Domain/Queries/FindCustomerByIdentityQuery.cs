using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Common.Models;
using ProjectSample.Infrastructure.NHibernate.Queries;

namespace ProjectSample.Core.Domain.Queries
{
    public class FindCustomerByIdentityQuery : NhQueryObject<Customer>
    {
        private readonly Identifier _identity;

        public FindCustomerByIdentityQuery(Identifier identity)
        {
            _identity = identity;
        }

        protected override Customer ExecuteCore(ISession session)
        {
            return session.Query<Customer>().SingleOrDefault(s => s.Identifier == _identity);
        }
    }
}