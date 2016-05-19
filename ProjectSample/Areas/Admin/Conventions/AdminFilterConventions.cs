using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMvc;
using FluentMvc.Configuration;
using FluentMvc.Constraints;
using FluentMvc.Conventions;
using ProjectSample.Areas.Admin.Filters;
using ProjectSample.Core.Infrastructure.Extensions;
using ProjectSample.Core.Infrastructure.Mvc.Controllers;

namespace ProjectSample.Areas.Admin.Conventions
{
    public class AdminFilterConventions : IFilterConvention
    {
        public void ApplyConvention(IFilterRegistration filterRegistration)
        {
            filterRegistration.WithFilter<EntityTypeFilter>(Apply.When<EntityTypeControllerRequestConstraint>());
        }
    }

    public class EntityTypeControllerRequestConstraint : IConstraint
    {
        public bool IsSatisfiedBy<T>(T selector) where T : RegistrySelector
        {
            return
                selector.ControllerDescriptor.ControllerType.IsAssignableToGenericType(typeof (EntityController<,,,,>));
        }
    }
}