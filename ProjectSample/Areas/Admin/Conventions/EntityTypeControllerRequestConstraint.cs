using FluentMvc;
using FluentMvc.Constraints;
using ProjectSample.Infrastructure.Extensions;
using ProjectSample.Infrastructure.Mvc.Controllers;

namespace ProjectSample.Areas.Admin.Conventions
{
    public class EntityTypeControllerRequestConstraint : IConstraint
    {
        public bool IsSatisfiedBy<T>(T selector) where T : RegistrySelector
        {
            return
                selector.ControllerDescriptor.ControllerType.IsAssignableToGenericType(typeof (EntityController<,,,,>));
        }
    }
}