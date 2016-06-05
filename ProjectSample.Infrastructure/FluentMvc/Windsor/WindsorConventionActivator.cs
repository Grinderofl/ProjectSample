using System;
using Castle.Windsor;
using FluentMvc.Conventions;

namespace ProjectSample.Infrastructure.FluentMvc.Windsor
{
    public class WindsorConventionActivator : IFilterConventionActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorConventionActivator(IWindsorContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            _container = container;
        }

        public virtual IFilterConvention Activate(Type type)
        {
            return _container.Resolve(type) as IFilterConvention;
        }
    }
}