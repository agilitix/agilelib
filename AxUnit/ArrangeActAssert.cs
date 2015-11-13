using System;
using NUnit.Framework;

namespace AxUnit
{
    public class ArrangeActAssert
    {
        /// <summary>
        /// Prepare the environment then run the test.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            Arrange();
            Act();
        }

        /// <summary>
        /// Cleanup code to run after the test has been done.
        /// </summary>
        [TestFixtureTearDown]
        public void TearDown()
        {
            Cleanup();
        }

        /// <summary>
        /// Create the context (objects, dependencies, mocks, data, etc.) need by the test.
        /// </summary>
        public virtual void Arrange()
        {
        }

        /// <summary>
        /// Run the test case.
        /// </summary>
        public virtual void Act()
        {
        }

        /// <summary>
        /// Cleanup code after the test is done.
        /// </summary>
        public virtual void Cleanup()
        {
        }

        /// <summary>
        /// Try to run an action and return the resulting exception.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
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