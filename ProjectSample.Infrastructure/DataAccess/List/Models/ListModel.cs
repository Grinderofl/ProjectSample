using System.Collections.Generic;

namespace ProjectSample.Infrastructure.DataAccess.List.Models
{
    public class ListModel<T>
    {
        public ListModel(IEnumerable<T> items, int total, int rowsPerPage, int page)
        {
            Items = items;
            Total = total;
            RowsPerPage = rowsPerPage;
            Page = page;
        }

        public int Total { get; }
        public int RowsPerPage { get; }

        public int Page { get; }

        public IEnumerable<T> Items { get; }
    }
}