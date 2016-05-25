using System;

namespace ProjectSample.Core.Infrastructure.DataAccess.List
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
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public Func<T, object> SortProperty { get; set; }
        public string SortDirection { get; set; } = "asc";

        public PageDescriptor(int page, int rowsPerPage)
        {
            Page = page;
            RowsPerPage = rowsPerPage;
            
        }

        public PageDescriptor() : this(1, 30)
        {
            
        }
    }
}