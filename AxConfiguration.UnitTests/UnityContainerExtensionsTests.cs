﻿using System;
using AxConfiguration.Interfaces;
using AxConfiguration.UnitTests.Test.Logger.Implementations;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;
using AxQuality;
using Microsoft.Practices.Unity;
using NFluent;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_default_container_resolving_file_logger : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider);
        }

        public override void Act()
        {
            ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("Logger");
        }

        [Test]
        public void Assert_resolved_logger_is_instance_of_file_logger()
        {
            Check.That(ResolvedLogger).IsInstanceOf<FileLogger>();
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            Check.That(ResolvedLogger.LoggerName).IsEqualTo("def_logger");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_default_container_resolving_global_vars : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider);
        }
    }

    public class UnityContainerExtensionsTests_default_container_resolving_base_var :
        UnityContainerExtensionsTests_default_container_resolving_global_vars
    {
        protected string BaseValue;

        public override void Act()
        {
            BaseValue = UnityContainerUnderTest.Resolve<string>("BaseValue");
        }

        [Test]
        public void Assert_resolved_base_value_is_high()
        {
            Check.That(BaseValue).IsEqualTo("High");
        }
    }

    public class UnityContainerExtensionsTests_default_container_resolving_logger_name :
        UnityContainerExtensionsTests_default_container_resolving_global_vars
    {
        protected string DefaultLoggerName;

        public override void Act()
        {
            DefaultLoggerName = UnityContainerUnderTest.Resolve<string>("DefaultLoggerName");
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            Check.That(DefaultLoggerName).IsEqualTo("def_logger");
        }
    }

    public class UnityContainerExtensionsTests_default_container_resolving_logger_file_name :
        UnityContainerExtensionsTests_default_container_resolving_global_vars
    {
        protected string DefaultLoggerFileName;

        public override void Act()
        {
            DefaultLoggerFileName = UnityContainerUnderTest.Resolve<string>("DefaultLoggerFileName");
        }

        [Test]
        public void Assert_resolved_log_file_name_is_FakeLogFile_log()
        {
            Check.That(DefaultLoggerFileName).IsEqualTo("FakeDefLogFile.log");
        }
    }

    public class UnityContainerExtensionsTests_default_container_resolving_timestamp_format :
        UnityContainerExtensionsTests_default_container_resolving_global_vars
    {
        protected string DefaultTimeStampFormat;

        public override void Act()
        {
            DefaultTimeStampFormat = UnityContainerUnderTest.Resolve<string>("DefaultTimeStampFormat");
        }

        [Test]
        public void Assert_resolved_time_stamp_is_yyyy_MM_dd_HH_mm_ss()
        {
            Check.That(DefaultTimeStampFormat).IsEqualTo("yyyy-MM-dd HH:mm:ss");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_loggers_container_resolving_console_logger : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider, "Loggers");
        }

        public override void Act()
        {
            ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("Logger");
        }

        [Test]
        public void Assert_resolved_logger_is_instance_of_console_logger()
        {
            Check.That(ResolvedLogger).IsInstanceOf<ConsoleLogger>();
        }

        [Test]
        public void Assert_resolved_logger_name_is_my_logger()
        {
            Check.That(ResolvedLogger.LoggerName).IsEqualTo("my_logger");
        }
    }

    public class UnityContainerExtensionsTests_loggers_container_resolving_unknown_instance_should_not_work :
        ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider, "Loggers");
        }

        public override void Act()
        {
            ExceptionWhileResolving =
                base.Trying(() => ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("UnknownLogger"));
        }

        [Test]
        public void Assert_resolution_failed_exception_has_been_raised()
        {
            Check.That(ExceptionWhileResolving).IsInstanceOf<ResolutionFailedException>();
        }

        [Test]
        public void Assert_the_instance_has_not_been_resolved()
        {
            Check.That(ResolvedLogger).IsNull();
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_loggers_container_resolving_global_vars : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider, "Loggers");
        }
    }

    public class UnityContainerExtensionsTests_loggers_container_resolving_logger_name :
        UnityContainerExtensionsTests_loggers_container_resolving_global_vars
    {
        protected string LoggerName;

        public override void Act()
        {
            LoggerName = UnityContainerUnderTest.Resolve<string>("LoggerName");
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            Check.That(LoggerName).IsEqualTo("my_logger");
        }
    }

    public class UnityContainerExtensionsTests_loggers_container_resolving_logger_file_name :
        UnityContainerExtensionsTests_loggers_container_resolving_global_vars
    {
        protected string LoggerFileName;

        public override void Act()
        {
            LoggerFileName = UnityContainerUnderTest.Resolve<string>("LoggerFileName");
        }

        [Test]
        public void Assert_resolved_log_file_name_is_FakeLogFile_log()
        {
            Check.That(LoggerFileName).IsEqualTo("FakeLogFile.log");
        }
    }

    public class UnityContainerExtensionsTests_loggers_container_resolving_timestamp_format :
        UnityContainerExtensionsTests_loggers_container_resolving_global_vars
    {
        protected string TimeStampFormat;

        public override void Act()
        {
            TimeStampFormat = UnityContainerUnderTest.Resolve<string>("TimeStampFormat");
        }

        [Test]
        public void Assert_resolved_time_stamp_is_yyyy_MM_dd_HH_mm_ss()
        {
            Check.That(TimeStampFormat).IsEqualTo("yyyy-MM-dd HH:mm:ss");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_loading_an_unknown_container_should_raise_an_exception : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        protected Exception LoadContainerException;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");
            UnityContainerUnderTest = new UnityContainer();
        }

        public override void Act()
        {
            LoadContainerException =
                base.Trying(() => UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider, "UnknownContainerName"));
        }

        [Test]
        public void Assert_should_raise_argument_exception()
        {
            Check.That(LoadContainerException).IsInstanceOf<ArgumentException>();
        }
    }

    public class UnityContainerExtensionsTests_loading_an_unknown_container_and_resolving_instances_should_not_work :
        ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigurationProvider ConfigurationProvider;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ConfigurationProvider = new ConfigurationProvider(TestDirectory + @"\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            base.Trying(() => UnityContainerUnderTest.LoadUnityConfiguration(ConfigurationProvider, "UnknownContainerName"));
        }

        public override void Act()
        {
            ExceptionWhileResolving = base.Trying(() => ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("Logger"));
        }

        [Test]
        public void Assert_resolution_failed_exception_has_been_raised()
        {
            Check.That(ExceptionWhileResolving).IsInstanceOf<ResolutionFailedException>();
        }

        [Test]
        public void Assert_the_instance_has_not_been_resolved()
        {
            Check.That(ResolvedLogger).IsNull();
        }
    }
}
