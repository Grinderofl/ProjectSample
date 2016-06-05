using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ProjectSample.Core.Domain.Mapping
{
    public class OrderStateOverride : IAutoMappingOverride<OrderState>
    {
        public void Override(AutoMapping<OrderState> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
        }
    }
}