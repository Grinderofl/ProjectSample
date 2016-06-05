using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Infrastructure.NHibernate.Queries;

namespace ProjectSample.Core.Domain.Queries
{
    public class FindProductsByPageQuery : NhQueryObject<IEnumerable<Product>>
    {
        private readonly int _numberOfItemsPerPage;
        private readonly int _page;

        public FindProductsByPageQuery(int page, int numberOfItemsPerPage)
        {
            _page = page;
            _numberOfItemsPerPage = numberOfItemsPerPage;
        }

        protected override IEnumerable<Product> ExecuteCore(ISession session)
        {
            return session.Query<Product>().OrderBy(x => x.Id).Skip((_page - 1)*_numberOfItemsPerPage).Take(_numberOfItemsPerPage);
        }
    }
}