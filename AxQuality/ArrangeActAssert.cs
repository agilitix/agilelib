using System;
using NUnit.Framework;

namespace AxQuality
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
            Startup();
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Cleanup();
        }

        /// <summary>
        /// Create required resources before the tests start.
        /// </summary>
        public virtual void Startup() {}

        /// <summary>
        /// Initialize the test environment (variables, objects, etc).
        /// </summary>
        public virtual void Arrange() {}

        /// <summary>
        /// Invoke the code under test.
        /// </summary>
        public virtual void Act() {}

        /// <summary>
        /// Cleanup resources after the tests are done.
        /// </summary>
        public virtual void Cleanup() {}

        /// <summary>
        /// Try to run an action, returns the thrown exception.
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