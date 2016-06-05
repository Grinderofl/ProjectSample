using System;
using Castle.MicroKernel;
using FluentValidation;

namespace ProjectSample.Infrastructure.FluentValidation.Windsor
{
    public class WindsorFluentValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public WindsorFluentValidatorFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
            => (IValidator) (_kernel.HasComponent(validatorType) ? _kernel.Resolve(validatorType) : null);
    }
}