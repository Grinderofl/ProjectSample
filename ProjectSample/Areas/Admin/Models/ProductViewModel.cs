using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductFields
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductLineItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}