using System;
using Castle.Windsor;
using FluentMvc.Configuration;

namespace ProjectSample.Infrastructure.FluentMvc
{
    public class WindsorObjectFactory : FluentMvcObjectFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorObjectFactory(IWindsorContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            _container = container;
        }

        public override TFilter Resolve<TFilter>(Type type)
        {
            return (TFilter)_container.Resolve(type);
        }
    }
}