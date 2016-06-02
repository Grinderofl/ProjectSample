using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMvc.Configuration;
using FluentMvc.Conventions;
using ProjectSample.Infrastructure.Mvc.Filters;

namespace ProjectSample.Core.Conventions
{
    public class GlobalFilterConvention : IFilterConvention
    {
        public void ApplyConvention(IFilterRegistration filterRegistration)
        {
            filterRegistration.WithFilter<DatabaseExceptionFilter>();
        }
    }
}