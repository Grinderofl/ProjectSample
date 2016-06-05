using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Infrastructure.DataAccess.List;
using ProjectSample.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Infrastructure.NHibernate.DataAccess.List.Impl
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
            var query = CreateQuery();
            query = AddSearchItems(pageDescriptor, query);
            var orderedQuery = OrderQuery(pageDescriptor, query);

            var totalItems = orderedQuery.Count();
            var pagedItems = PageQuery(pageDescriptor, query);
            var result = CreateListResult(pageDescriptor, totalItems, pagedItems);

            return result;
        }

        private static ListResult<T> CreateListResult(PageDescriptor<T> pageDescriptor, int totalItems,
            IEnumerable<T> pagedItems)
        {
            var result = new ListResult<T>(totalItems, pagedItems.ToList())
            {
                Page = pageDescriptor.Page,
                RowsPerPage = pageDescriptor.RowsPerPage
            };

            return result;
        }

        private static IEnumerable<T> PageQuery(PageDescriptor<T> pageDescriptor, IQueryable<T> query)
        {
            var pagesToSkip = (pageDescriptor.Page - 1)*pageDescriptor.RowsPerPage;
            return query.Skip(pagesToSkip).Take(pageDescriptor.RowsPerPage);
        }

        private static IOrderedQueryable<T> OrderQuery(PageDescriptor<T> pageDescriptor, IQueryable<T> query)
        {
            return pageDescriptor.SortDirection == "asc"
                ? query.OrderBy(pageDescriptor.SortProperty)
                : query.OrderByDescending(pageDescriptor.SortProperty);
        }

        private static IQueryable<T> AddSearchItems(PageDescriptor<T> pageDescriptor, IQueryable<T> query)
        {
            foreach (var searchItem in pageDescriptor.Search.SearchItems)
            {
                query = query.Where(searchItem);
            }

            return query;
        }

        private IQueryable<T> CreateQuery()
        {
            return _session.Query<T>();
        }
    }
}