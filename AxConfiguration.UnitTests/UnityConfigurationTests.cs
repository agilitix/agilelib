using System;
using System.Configuration;
using System.IO;
using AxConfiguration.Interfaces;
using AxConfiguration.UnitTests.Test.Logger.Implementations;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;
using AxQuality;
using FluentAssertions;
using Unity;
using NUnit.Framework;
using Unity.Exceptions;

namespace AxConfiguration.UnitTests
{
    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    internal class UnityConfigurationTests_default_container_resolving_file_logger : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration();
            UnityContainerUnderTest.LoadConfiguration(TestDirectory + @"\UnityConfiguration\unity.main.config");
        }

        public override void Act()
        {
            ResolvedLogger = UnityContainerUnderTest.Configuration.Resolve<ILogger>("Logger");
        }

        [Test]
        public void Assert_resolved_logger_is_instance_of_file_logger()
        {
            ResolvedLogger.Should().BeOfType<FileLogger>();
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            ResolvedLogger.LoggerName.Should().Be("def_logger");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    internal class UnityConfigurationTests_default_container_resolving_global_vars : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration();
            UnityContainerUnderTest.LoadConfiguration(TestDirectory + @"\UnityConfiguration\unity.main.config");
        }
    }

    internal class UnityConfigurationTests_default_container_resolving_base_var : UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string BaseValue;

        public override void Act()
        {
            BaseValue = UnityContainerUnderTest.Configuration.Resolve<string>("BaseValue");
        }

        [Test]
        public void Assert_resolved_base_value_is_high()
        {
            BaseValue.Should().Be("High");
        }
    }

    internal class UnityConfigurationTests_default_container_resolving_logger_name : UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string DefaultLoggerName;

        public override void Act()
        {
            DefaultLoggerName = UnityContainerUnderTest.Configuration.Resolve<string>("DefaultLoggerName");
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            DefaultLoggerName.Should().Be("def_logger");
        }
    }

    internal class UnityConfigurationTests_default_container_resolving_logger_file_name : UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string DefaultLoggerFileName;

        public override void Act()
        {
            DefaultLoggerFileName = UnityContainerUnderTest.Configuration.Resolve<string>("DefaultLoggerFileName");
        }

        [Test]
        public void Assert_resolved_log_file_name_is_FakeDefLogFile_log()
        {
            DefaultLoggerFileName.Should().Be("FakeDefLogFile.log");
        }
    }

    internal class UnityConfigurationTests_default_container_resolving_timestamp_format : UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string DefaultTimeStampFormat;

        public override void Act()
        {
            DefaultTimeStampFormat = UnityContainerUnderTest.Configuration.Resolve<string>("DefaultTimeStampFormat");
        }

        [Test]
        public void Assert_resolved_time_stamp_is_DEF_yyyy_MM_dd_HH_mm_ss()
        {
            DefaultTimeStampFormat.Should().Be("DEF yyyy-MM-dd HH:mm:ss");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    internal class UnityConfigurationTests_loggers_container_resolving_unknown_instance_should_not_work : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration();
            UnityContainerUnderTest.LoadConfiguration(TestDirectory + @"\UnityConfiguration\unity.main.config");
        }

        public override void Act()
        {
            ExceptionWhileResolving = Trying(() => ResolvedLogger = UnityContainerUnderTest.Configuration.Resolve<ILogger>("UnknownLogger"));
        }

        [Test]
        public void Assert_resolution_failed_exception_has_been_raised()
        {
            ExceptionWhileResolving.Should().BeOfType<ResolutionFailedException>();
        }

        [Test]
        public void Assert_the_instance_has_not_been_resolved()
        {
            ResolvedLogger.Should().BeNull();
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    internal class UnityConfigurationTests_loading_an_unknown_container_should_raise_an_exception : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected Exception LoadContainerException;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Act()
        {
            LoadContainerException = Trying(() => UnityContainerUnderTest = new UnityConfiguration(TestDirectory + @"\UnityConfiguration\unity.main.config", "UnknownContainerName"));
        }

        [Test]
        public void Assert_should_raise_argument_exception()
        {
            LoadContainerException.Should().BeOfType<ArgumentException>();
        }
    }

    internal class UnityConfigurationTests_loading_an_unknown_container_should_not_work : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected Exception ExceptionWhileLoading;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Act()
        {
            ExceptionWhileLoading = Trying(() => UnityContainerUnderTest = new UnityConfiguration(TestDirectory + @"\UnityConfiguration\unity.main.config", "UnknownContainerName"));
        }

        [Test]
        public void Assert_resolution_failed_exception_has_been_raised()
        {
            ExceptionWhileLoading.Should().BeOfType<ArgumentException>();
        }
    }
}
