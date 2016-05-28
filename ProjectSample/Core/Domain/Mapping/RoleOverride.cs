using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

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