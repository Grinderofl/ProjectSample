using Moq;
using NUnit.Framework;

namespace ProjectSample.UnitTests
{
    public class TestBase
    {
        protected virtual Mock<T> CreateDependency<T>() where T : class
        {
            return new Mock<T>();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SharedContext();
            Context();
        }

        protected virtual void SharedContext()
        {
        }

        protected virtual void Context()
        {
        }
    }
}