﻿using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ProjectSample.Core.Domain.Mapping
{
    public class OrderOverride : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.HasMany(x => x.OrderStateHistory).AsSet().Cascade.All();
            mapping.HasMany(x => x.Items).AsSet().Cascade.AllDeleteOrphan();
            mapping.HasMany(x => x.Shipments).AsSet().Cascade.AllDeleteOrphan();
            mapping.References(x => x.CurrentState).Not.Nullable();
        }
    }
}