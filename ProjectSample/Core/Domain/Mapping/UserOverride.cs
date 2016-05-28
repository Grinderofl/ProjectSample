using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ProjectSample.Core.Domain.Mapping
{
    public class UserOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.References(x => x.Customer).Cascade.All();
        }
    }
}