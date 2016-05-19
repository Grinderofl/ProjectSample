using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace ProjectSample.Core.Domain.Mapping
{
    public class ShipmentOverride : IAutoMappingOverride<Shipment>
    {
        public void Override(AutoMapping<Shipment> mapping)
        {
            mapping.HasMany(x => x.ShipmentItems).AsSet().Cascade.DeleteOrphan();
            mapping.References(x => x.Order).Index("IX_Shipment_Order_OrderId");
        }
    }
}