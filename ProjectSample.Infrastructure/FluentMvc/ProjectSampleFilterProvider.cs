using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectSample.Infrastructure.FluentMvc
{
    public class ProjectSampleFilterProvider : IFilterProvider
    {
        private readonly IFilterProvider _provider;

        public ProjectSampleFilterProvider(IFilterProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            _provider = provider;
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return _provider.GetFilters(controllerContext, actionDescriptor);
        }
    }
}