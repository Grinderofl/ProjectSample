using System.Reflection;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.Windsor;

namespace ProjectSample.Application.Configuration
{
    public class ProjectSampleAssemblyConfiguration : AssemblyConfiguration
    {
        public override Assembly[] Assemblies => new[]
        {
            typeof(MvcApplication).Assembly,
            typeof(User).Assembly,
            typeof(AssemblyConfiguration).Assembly
        };
    }
}