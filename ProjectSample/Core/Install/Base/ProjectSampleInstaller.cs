using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Configuration;
using ProjectSample.Infrastructure.Windsor;

namespace ProjectSample.Core.Install.Base
{
    public abstract class ProjectSampleInstaller : AbstractAssemblyInstaller<ProjectSampleAssemblyConfiguration>
    {
    }
}