using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ProjectSample.Core.Domain.Mapping
{
    public class ShipmentItemOverride : IAutoMappingOverride<ShipmentItem>
    {
        public void Override(AutoMapping<ShipmentItem> mapping)
        {
            mapping.IgnoreProperty(x => x.Order);
            mapping.IgnoreProperty(x => x.Product);
            mapping.References(x => x.OrderItem).Not.Nullable();
        }
    }
}