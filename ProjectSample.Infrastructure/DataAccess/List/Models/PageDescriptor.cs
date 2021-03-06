using System;
using System.Linq.Expressions;

namespace ProjectSample.Infrastructure.DataAccess.List.Models
{
    public abstract class PageDescriptor
    {
        public static PageDescriptor<T> Create<T>()
        {
            return new PageDescriptor<T>();
        }
    }

    public class PageDescriptor<T> : PageDescriptor
    {
        public PageDescriptor(int page, int rowsPerPage)
        {
            Page = page;
            RowsPerPage = rowsPerPage;
        }

        public PageDescriptor() : this(1, 30)
        {
        }

        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public Expression<Func<T, object>> SortProperty { get; set; }
        public string SortDirection { get; set; } = "asc";
        public Search<T> Search { get; } = new Search<T>();

        public void AddSearchItem(Expression<Func<T, bool>> expression)
        {
            Search.AddItem(expression);
        }
    }
}