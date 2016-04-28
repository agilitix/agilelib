using System;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;
using AxUnit;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    public class UnityContainerExtensionsTests : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityContainer();
        }
    }

    public class UnityContainerExtensionsTests_default_container : UnityContainerExtensionsTests
    {
        protected Exception LoadDefaultContainerException;

        public override void Act()
        {
            LoadDefaultContainerException =
                base.Try(() => UnityContainerUnderTest.LoadConfigurationFromFolder(@".\Configuration"));
        }

        [Test]
        public void Check_no_exceptions_after_loading_default_container()
        {
            Assert.IsNull(LoadDefaultContainerException);
        }
    }

    public class UnityContainerExtensionsTests_loggers_container : UnityContainerExtensionsTests
    {
        protected Exception LoadLoggersContainerException;

        public override void Act()
        {
            LoadLoggersContainerException =
                base.Try(() => UnityContainerUnderTest.LoadConfigurationFromFolder(@".\Configuration", "Loggers"));
        }

        [Test]
        public void Check_no_exceptions_after_loading_loggers_container()
        {
            Assert.IsNull(LoadLoggersContainerException);
        }
    }
}