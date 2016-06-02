using System.Web.Mvc;
using FluentMvc.Configuration;
using FluentMvc.Conventions;
using ProjectSample.Areas.Admin.Filters;

namespace ProjectSample.Areas.Admin.Conventions
{
    public class AdminFilterConventions : IFilterConvention
    {
        public void ApplyConvention(IFilterRegistration filterRegistration)
        {
            filterRegistration.WithFilter<EntityTypeFilter>(Apply.When<EntityTypeControllerRequestConstraint>());
            //filterRegistration.WithFilter<AuthorizeAttribute>(Apply.ForArea<AdminAreaRegistration>());
        }
    }
}