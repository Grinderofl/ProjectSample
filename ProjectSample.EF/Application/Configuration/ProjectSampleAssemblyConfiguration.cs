using System.Reflection;
using ProjectSample.EF.Core.Domain;
using ProjectSample.Infrastructure.Windsor;

namespace ProjectSample.EF.Application.Configuration
{
    public class ProjectSampleAssemblyConfiguration : AssemblyConfiguration
    {
        public override Assembly[] Assemblies => new[]
        {
            typeof(User).Assembly,
            typeof(AssemblyConfiguration).Assembly
        };
    }
}