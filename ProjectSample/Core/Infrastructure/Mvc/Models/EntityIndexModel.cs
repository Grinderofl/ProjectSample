using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Core.Infrastructure.Mvc.Models
{
    public class EntityIndexModel
    {
        public IEnumerable<string> Headers { get; set; }
        public dynamic Items { get; set; }
    }
}