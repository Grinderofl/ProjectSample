using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace ProjectSample.Infrastructure.NHibernate.Conventions
{
    public class ProjectSampleForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type) => $"{property?.Name ?? type.Name}Id";
    }
}