using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace ProjectSample.Core.Domain.Mapping
{
    public class CustomerOverride : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.HasOne(x => x.Basket).Cascade.All().LazyLoad(Laziness.Proxy);
        }
    }
}