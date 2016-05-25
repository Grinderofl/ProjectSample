using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Infrastructure.DataAccess.List;

namespace ProjectSample.Core.Infrastructure.NHibernate.DataAccess.List.Impl
{
    public class NhListService<T> : IListService<T>
    {
        private ISession _session;

        public NhListService(ISession session)
        {
            _session = session;
        }

        public virtual ListResult<T> GetListResult(PageDescriptor<T> pageDescriptor)
        {
            var entities = _session.Query<T>();

            var query = entities;

            var orderedQuery = pageDescriptor.SortDirection == "asc"
                ? query.OrderBy(x => pageDescriptor.SortProperty(x))
                : query.OrderByDescending(x => pageDescriptor.SortProperty(x));

            var totalItems = orderedQuery.Count();
            var pagesToSkip = (pageDescriptor.Page - 1)*pageDescriptor.RowsPerPage;
            var pagedItems = orderedQuery.Skip(pagesToSkip).Take(pageDescriptor.RowsPerPage);
            
            var result = new ListResult<T>(totalItems, pagedItems);

            result.Page = pageDescriptor.Page;
            result.RowsPerPage = pageDescriptor.RowsPerPage;

            return result;

        }
    }
}