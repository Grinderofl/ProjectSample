using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using ProjectSample.Infrastructure.Windsor;

namespace ProjectSample.Core.Configuration
{
    public class ProjectSampleAssemblyConfiguration : AssemblyConfiguration
    {
        public override Assembly[] Assemblies => new[]
        {
            typeof(MvcApplication).Assembly,
        };
    }
}