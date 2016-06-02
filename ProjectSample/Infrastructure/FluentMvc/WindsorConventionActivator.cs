using System;
using Castle.Windsor;
using FluentMvc.Conventions;

namespace ProjectSample.Infrastructure.FluentMvc
{
    public class WindsorConventionActivator : IFilterConventionActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorConventionActivator(IWindsorContainer container)
        {
            this._container = container;
        }

        public IFilterConvention Activate(Type type)
        {
            return _container.Resolve(type) as IFilterConvention;
        }
    }
}