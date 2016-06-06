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
            SharedSetup();
            Setup();
        }

        protected virtual void SharedSetup()
        {
        }

        protected virtual void Setup()
        {
        }
    }
}