using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace ProjectSample.Core.Domain.Mapping
{
    public class OrderOverride : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.HasMany(x => x.OrderStateHistory).AsSet().Cascade.All().Access.CamelCaseField(Prefix.Underscore);
            mapping.HasMany(x => x.OrderItems).AsSet().Cascade.DeleteOrphan().Access.CamelCaseField(Prefix.Underscore);
            mapping.HasMany(x => x.Shipments).AsSet().Cascade.DeleteOrphan().Access.CamelCaseField(Prefix.Underscore);
            mapping.References(x => x.CurrentState).Not.Nullable();
        }
    }
}