using System;
using NUnit.Framework;

namespace AxUnit
{
    /// <summary>
    /// Arrange is variable declaration and initialization for the test.
    /// Act is invoking the code under test.
    /// Assert is the methods to verify that expectations were met.
    /// </summary>
    public class ArrangeActAssert
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Cleanup();
        }

        /// <summary>
        /// Initialize the test environment (variables, objects, etc).
        /// </summary>
        public virtual void Arrange() {}

        /// <summary>
        /// Invoke the code under test.
        /// </summary>
        public virtual void Act() {}

        /// <summary>
        /// Cleanup code after the test is done.
        /// </summary>
        public virtual void Cleanup() {}

        /// <summary>
        /// Try to run an action, returns the thrown exception.
        /// </summary>
        public Exception Try(Action action)
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