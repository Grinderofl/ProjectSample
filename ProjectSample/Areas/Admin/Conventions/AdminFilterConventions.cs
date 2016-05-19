using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentMvc.Configuration;
using FluentMvc.Conventions;
using ProjectSample.Areas.Admin.Controllers;
using ProjectSample.Areas.Admin.Filters;

namespace ProjectSample.Areas.Admin.Conventions
{
    public class AdminFilterConventions : IFilterConvention
    {
        public void ApplyConvention(IFilterRegistration filterRegistration)
        {
            filterRegistration.WithFilter<EntityTypeFilter>(Apply.When<EntityTypeControllerRequestConstraint>());
            filterRegistration.WithFilter<ValidateAntiForgeryTokenAttribute>(
                Apply.For<ProductController>(x => x.Create(null))
                    .AndFor<ProductController>(x => x.Delete(0))
                    .AndFor<ProductController>(x => x.Edit(0, null)));
        }
    }
}