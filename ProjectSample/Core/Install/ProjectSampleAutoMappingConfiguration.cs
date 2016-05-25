using System;
using FluentNHibernate.Automapping;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Install
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
    }
}