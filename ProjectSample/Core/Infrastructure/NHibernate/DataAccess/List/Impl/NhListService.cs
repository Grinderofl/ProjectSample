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
        private readonly ISession _session;

        public NhListService(ISession session)
        {
            _session = session;
        }

        public virtual ListResult<T> GetListResult(PageDescriptor<T> pageDescriptor)
        {
            var entities = _session.Query<T>();

            var query = entities;
            foreach (var searchItem in pageDescriptor.Search.SearchItems)
            {
                query = query.Where(searchItem);
            }

            var orderedQuery = pageDescriptor.SortDirection == "asc"
                ? query.OrderBy(pageDescriptor.SortProperty)
                : query.OrderByDescending(pageDescriptor.SortProperty);

            var totalItems = orderedQuery.Count();
            var pagesToSkip = (pageDescriptor.Page - 1)*pageDescriptor.RowsPerPage;
            var pagedItems = orderedQuery.Skip(pagesToSkip).Take(pageDescriptor.RowsPerPage).ToList();
            
            var result = new ListResult<T>(totalItems, pagedItems);

            result.Page = pageDescriptor.Page;
            result.RowsPerPage = pageDescriptor.RowsPerPage;

            return result;

        }
    }
}