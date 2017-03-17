using System;
using System.IO;
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

    public class UnityConfigurationTests_default_container_resolving_file_logger : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration();
            UnityContainerUnderTest.LoadDefaultFile(TestDirectory + @"\Configuration");
        }

        public override void Act()
        {
            ResolvedLogger = UnityContainerUnderTest.Container.Resolve<ILogger>("Logger");
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

    public class UnityConfigurationTests_default_container_resolving_global_vars : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration();
            UnityContainerUnderTest.LoadDefaultFile(TestDirectory + @"\Configuration");
        }
    }

    public class UnityConfigurationTests_default_container_resolving_base_var :
        UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string BaseValue;

        public override void Act()
        {
            BaseValue = UnityContainerUnderTest.Container.Resolve<string>("BaseValue");
        }

        [Test]
        public void Assert_resolved_base_value_is_high()
        {
            Check.That(BaseValue).IsEqualTo("High");
        }
    }

    public class UnityConfigurationTests_default_container_resolving_logger_name :
        UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string DefaultLoggerName;

        public override void Act()
        {
            DefaultLoggerName = UnityContainerUnderTest.Container.Resolve<string>("DefaultLoggerName");
        }

        [Test]
        public void Assert_resolved_logger_name_is_def_logger()
        {
            Check.That(DefaultLoggerName).IsEqualTo("def_logger");
        }
    }

    public class UnityConfigurationTests_default_container_resolving_logger_file_name :
        UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string DefaultLoggerFileName;

        public override void Act()
        {
            DefaultLoggerFileName = UnityContainerUnderTest.Container.Resolve<string>("DefaultLoggerFileName");
        }

        [Test]
        public void Assert_resolved_log_file_name_is_FakeDefLogFile_log()
        {
            Check.That(DefaultLoggerFileName).IsEqualTo("FakeDefLogFile.log");
        }
    }

    public class UnityConfigurationTests_default_container_resolving_timestamp_format :
        UnityConfigurationTests_default_container_resolving_global_vars
    {
        protected string DefaultTimeStampFormat;

        public override void Act()
        {
            DefaultTimeStampFormat = UnityContainerUnderTest.Container.Resolve<string>("DefaultTimeStampFormat");
        }

        [Test]
        public void Assert_resolved_time_stamp_is_DEF_yyyy_MM_dd_HH_mm_ss()
        {
            Check.That(DefaultTimeStampFormat).IsEqualTo("DEF yyyy-MM-dd HH:mm:ss");
        }
    }

    //================================================================================================================
    //================================================================================================================
    //================================================================================================================

    public class UnityConfigurationTests_loggers_container_resolving_unknown_instance_should_not_work :
        ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration();
            UnityContainerUnderTest.LoadDefaultFile(TestDirectory + @"\Configuration");
        }

        public override void Act()
        {
            ExceptionWhileResolving =
                base.Trying(() => ResolvedLogger = UnityContainerUnderTest.Container.Resolve<ILogger>("UnknownLogger"));
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

    public class UnityConfigurationTests_loading_an_unknown_container_should_raise_an_exception : ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected Exception LoadContainerException;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration("UnknownContainerName");
        }

        public override void Act()
        {
            LoadContainerException =
                base.Trying(() => UnityContainerUnderTest.LoadDefaultFile(TestDirectory + @"\Configuration"));
        }

        [Test]
        public void Assert_should_raise_argument_exception()
        {
            Check.That(LoadContainerException).IsInstanceOf<FileLoadException>();
        }
    }

    public class UnityConfigurationTests_loading_an_unknown_container_and_resolving_instances_should_not_work :
        ArrangeActAssert
    {
        protected IUnityConfiguration UnityContainerUnderTest;
        protected Exception ExceptionWhileResolving;
        protected ILogger ResolvedLogger;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            UnityContainerUnderTest = new UnityConfiguration("UnknownContainerName");
            base.Trying(() => UnityContainerUnderTest.LoadDefaultFile(TestDirectory + @"\Configuration"));
        }

        public override void Act()
        {
            ExceptionWhileResolving = base.Trying(() => ResolvedLogger = UnityContainerUnderTest.Container.Resolve<ILogger>("Logger"));
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
