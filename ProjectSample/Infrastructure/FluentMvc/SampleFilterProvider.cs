using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectSample.Infrastructure.FluentMvc
{
    public class SampleFilterProvider : IFilterProvider
    {
        private readonly IFilterProvider _provider;

        public SampleFilterProvider(IFilterProvider provider)
        {
            this._provider = provider;
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return _provider.GetFilters(controllerContext, actionDescriptor);
        }
    }
}