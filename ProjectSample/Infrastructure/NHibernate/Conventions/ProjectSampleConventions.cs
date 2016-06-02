using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace ProjectSample.Infrastructure.NHibernate.Conventions
{
    public class ProjectSampleConventions :
        IHasManyConvention,
        IIdConvention,
        IHasManyToManyConvention,
        IReferenceConvention,
        ICollectionConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.AsSet();
            instance.LazyLoad();
            instance.Access.CamelCaseField(CamelCasePrefix.Underscore);
        }

        public void Apply(IIdentityInstance instance)
        {
            instance.Column($"{instance.EntityType.Name}Id");
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            var instanceNames = new SortedSet<string>()
            {
                instance.ChildType.Name,
                instance.EntityType.Name
            };

            instance.LazyLoad();
            instance.Table($"{instanceNames.ElementAt(0)}To{instanceNames.ElementAt(1)}");
        }

        public void Apply(IManyToOneInstance instance)
        {
        }

        public void Apply(ICollectionInstance instance)
        {
            instance.AsSet();
            instance.LazyLoad();
        }
    }
}
