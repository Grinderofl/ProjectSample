﻿using System;
using System.Reflection;

namespace ProjectSample.Infrastructure.Windsor.Extensions
{
    public static class AssemblyConfigurationExtensions
    {
        public static void Accept(this AssemblyConfiguration configuration, Action<Assembly> action)
        {
            foreach (var asm in configuration.Assemblies)
                action(asm);
        }

        public static void VisitAssemblies(this Action<Assembly> action, AssemblyConfiguration configuration)
            => configuration.Accept(action);
    }
}