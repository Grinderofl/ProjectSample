using System.Collections.Generic;

namespace ProjectSample.Infrastructure.DataAccess.List.Models
{
    public class ListResult<T>
    {
        public ListResult(int total, IEnumerable<T> items)
        {
            Total = total;
            Items = items;
        }

        public int Total { get; private set; }
        public IEnumerable<T> Items { get; private set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
    }
}