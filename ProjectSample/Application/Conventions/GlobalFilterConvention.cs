using FluentMvc.Configuration;
using FluentMvc.Conventions;
using ProjectSample.Infrastructure.Mvc.Filters;

namespace ProjectSample.Application.Conventions
{
    public class GlobalFilterConvention : IFilterConvention
    {
        public void ApplyConvention(IFilterRegistration filterRegistration)
        {
            filterRegistration.WithFilter<DatabaseExceptionFilter>();
        }
    }
}