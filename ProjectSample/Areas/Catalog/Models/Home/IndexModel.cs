using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Areas.Catalog.Models.Home
{
    public class IndexModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }
    }
}