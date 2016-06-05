using System.Collections.Generic;
using System.Reflection;

namespace ProjectSample.Infrastructure.Windsor
{
    public abstract class AssemblyConfiguration
    {
        public abstract Assembly[] Assemblies { get; }
    }
}