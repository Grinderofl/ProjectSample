using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Infrastructure.DataAccess;
using ProjectSample.Core.Infrastructure.NHibernate.Queries;
using ProjectSample.Core.Infrastructure.Queries;

namespace ProjectSample.Core.Domain.Queries
{
    public class FindProductsByPageQuery : NhQueryObject<IEnumerable<Product>>
    {
        private int _page;
        private readonly int _numberOfItemsPerPage;

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