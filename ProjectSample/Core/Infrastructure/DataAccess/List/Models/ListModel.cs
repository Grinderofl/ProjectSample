using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Core.Infrastructure.DataAccess.List.Models
{
    public class ListModel<T>
    {
        public int Total { get; }
        public int RowsPerPage { get; }

        public int Page { get; }

        public IEnumerable<T> Items { get; }

        public ListModel(IEnumerable<T> items, int total, int rowsPerPage, int page)
        {
            Items = items;
            Total = total;
            RowsPerPage = rowsPerPage;
            Page = page;
        }
    }
}