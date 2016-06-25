using System;
using System.Collections.Generic;
using AxConfiguration.ConfigFileProvider;
using AxConfiguration.Interfaces;
using AxConfiguration.UnitTests.Test.Logger.Implementations;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;
using AxUnit;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_default_container_resolving_file_logger : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;
        protected ILogger ResolvedLogger;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider);
        }

        public override void Act()
        {
            ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("Logger");
        }

        [Test]
        public void Assert_resolved_logger_is_instance_of_file_logger()
        {
            Assert.IsInstanceOf<FileLogger>(ResolvedLogger);
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            Assert.AreEqual(ResolvedLogger.LoggerName, "def_logger");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_default_container_resolving_global_vars : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider);
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
            Assert.AreEqual(BaseValue, "High");
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
            Assert.AreEqual(DefaultLoggerName, "def_logger");
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
            Assert.AreEqual(DefaultLoggerFileName, "FakeDefLogFile.log");
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
            Assert.AreEqual(DefaultTimeStampFormat, "yyyy-MM-dd HH:mm:ss");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_loggers_container_resolving_console_logger : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;
        protected ILogger ResolvedLogger;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider, "Loggers");
        }

        public override void Act()
        {
            ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("Logger");
        }

        [Test]
        public void Assert_resolved_logger_is_instance_of_console_logger()
        {
            Assert.IsInstanceOf<ConsoleLogger>(ResolvedLogger);
        }

        [Test]
        public void Assert_resolved_logger_name_is_my_logger()
        {
            Assert.AreEqual(ResolvedLogger.LoggerName, "my_logger");
        }
    }

    public class UnityContainerExtensionsTests_loggers_container_resolving_unknown_instance_should_not_work :
        ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider, "Loggers");
        }

        public override void Act()
        {
            ExceptionWhileResolving =
                base.Trying(() => ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("UnknownLogger"));
        }

        [Test]
        public void Assert_resolution_failed_exception_has_been_raised()
        {
            Assert.IsInstanceOf<ResolutionFailedException>(ExceptionWhileResolving);
        }

        [Test]
        public void Assert_the_instance_has_not_been_resolved()
        {
            Assert.IsNull(ResolvedLogger);
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_loggers_container_resolving_global_vars : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider, "Loggers");
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
            Assert.AreEqual(LoggerName, "my_logger");
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
            Assert.AreEqual(LoggerFileName, "FakeLogFile.log");
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
            Assert.AreEqual(TimeStampFormat, "yyyy-MM-dd HH:mm:ss");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityContainerExtensionsTests_loading_an_unknown_container_should_raise_an_exception : ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;
        protected Exception LoadContainerException;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");
            UnityContainerUnderTest = new UnityContainer();
        }

        public override void Act()
        {
            LoadContainerException =
                base.Trying(() => UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider,
                                                                              "UnknownContainerName"));
        }

        [Test]
        public void Assert_should_raise_argument_exception()
        {
            Assert.IsInstanceOf<ArgumentException>(LoadContainerException);
        }
    }

    public class UnityContainerExtensionsTests_loading_an_unknown_container_and_resolving_instances_should_not_work :
        ArrangeActAssert
    {
        protected IUnityContainer UnityContainerUnderTest;
        protected IConfigFileProvider ConfigFileProvider;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;

        public override void Arrange()
        {
            ConfigFileProvider = new UnityConfigFileProvider(@".\Configuration");

            UnityContainerUnderTest = new UnityContainer();
            base.Trying(() => UnityContainerUnderTest.LoadUnityConfiguration(ConfigFileProvider,
                                                                          "UnknownContainerName"));
        }

        public override void Act()
        {
            ExceptionWhileResolving = base.Trying(() => ResolvedLogger = UnityContainerUnderTest.Resolve<ILogger>("Logger"));
        }

        [Test]
        public void Assert_resolution_failed_exception_has_been_raised()
        {
            Assert.IsInstanceOf<ResolutionFailedException>(ExceptionWhileResolving);
        }

        [Test]
        public void Assert_the_instance_has_not_been_resolved()
        {
            Assert.IsNull(ResolvedLogger);
        }
    }
}