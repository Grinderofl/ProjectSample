using System;
using System.Linq;

namespace ProjectSample.Core.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAssignableToGenericType(this Type type, Type genericType)
        {
            var interfaceTypes = type.GetInterfaces();

            if (interfaceTypes.Where(it => it.IsGenericType).Any(it => it.GetGenericTypeDefinition() == genericType))
                return true;

            var baseType = type.BaseType;
            if (baseType == null)
                return false;

            return baseType.IsGenericType &&
                   baseType.GetGenericTypeDefinition() == genericType ||
                   IsAssignableToGenericType(baseType, genericType);
        }
    }
}