using System;
using FluentNHibernate.Automapping;
using ProjectSample.Infrastructure.Domain.Base;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Core.Configuration
{
    public class ProjectSampleAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return base.ShouldMap(type) && type.IsSubclassOf(typeof (Entity));
        }

        public override bool IsComponent(Type type)
        {
            return base.IsComponent(type) && type.Namespace.EndsWith("Components");
        }

        public override bool IsDiscriminated(Type type)
        {
            return base.IsDiscriminated(type) && type == typeof(UserBase);
        }
    }
}