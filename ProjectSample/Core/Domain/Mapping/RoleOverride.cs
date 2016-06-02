using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Core.Domain.Mapping
{
    public class RoleOverride : IAutoMappingOverride<Role>
    {
        public void Override(AutoMapping<Role> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
        }
    }
}