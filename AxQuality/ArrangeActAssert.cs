using System;
using NUnit.Framework;

namespace AxQuality
{
    /// <summary>
    /// Arrange is variable declaration and initialization for the test.
    /// Act is invoking the code under test.
    /// Assert are the [Test] methods to check the actual results against expected results.
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

        /// <summary>
        /// Create required resources before all the [Test] methods start running.
        /// </summary>
        public virtual void OneTimeSetUp()
        {
        }

        /// <summary>
        /// Initialize the test requirements (values, objects, mocks, etc).
        /// </summary>
        public virtual void Arrange()
        {
        }

        /// <summary>
        /// Invoke the code/method under test.
        /// </summary>
        public virtual void Act()
        {
        }

        /// <summary>
        /// Cleanup the resources after all the [Test] methods have been executed.
        /// </summary>
        public virtual void OneTimeTearDown()
        {
        }

        /// <summary>
        /// Try to run an action and returns the thrown exception.
        /// </summary>
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
