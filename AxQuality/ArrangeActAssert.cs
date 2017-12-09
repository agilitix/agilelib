using System;
using NUnit.Framework;

namespace AxQuality
{
    /// <summary>
    /// Arrange is variable declaration and initialization for the test.
    /// Act is invoking the code under test.
    /// Assert are the [Test] methods to compare actual results against expected results.
    /// </summary>
    public class ArrangeActAssert
    {
        [OneTimeSetUp]
        public void OneTimeSetUpBase()
        {
            OneTimeSetUp();
            Arrange();
            Act();
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase()
        {
            OneTimeTearDown();
        }

        public virtual void OneTimeSetUp()
        {
        }

        public virtual void OneTimeTearDown()
        {
        }

        public virtual void Arrange()
        {
        }

        public virtual void Act()
        {
        }

        public Exception Trying(Action action)
        {
            Exception result = null;
            try
            {
                action();
            }
            catch (Exception e)
            {
                result = e;
            }
            return result;
        }
    }
}
