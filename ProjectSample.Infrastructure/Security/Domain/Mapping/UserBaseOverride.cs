using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ProjectSample.Infrastructure.Security.Domain.Mapping
{
    public class UserBaseOverride : IAutoMappingOverride<UserBase>
    {
        public void Override(AutoMapping<UserBase> mapping)
        {
            mapping.References(x => x.Role);
            mapping.Id(x => x.Id).GeneratedBy.GuidComb();
        }
    }
}