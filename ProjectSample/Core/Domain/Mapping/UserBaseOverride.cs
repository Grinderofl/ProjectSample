using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Core.Domain.Mapping
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