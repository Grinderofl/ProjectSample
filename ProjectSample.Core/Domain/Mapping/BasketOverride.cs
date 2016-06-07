using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ProjectSample.Core.Domain.Mapping
{
    public class BasketOverride : IAutoMappingOverride<Basket>
    {
        public void Override(AutoMapping<Basket> mapping)
        {
            mapping.HasMany(x => x.Items).AsList().Cascade.AllDeleteOrphan();
        }
    }
}