using AxConfiguration.UnitTests.Test.Logger.Implementations;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;
using AxUnit;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    // TODO

    //public class UnityContainerExtensionsTests : ArrangeActAssert
    //{
    //    protected IUnityContainer UnityContainerUnderTest;

    //    public override void Arrange()
    //    {
    //        UnityContainerUnderTest = new UnityContainer();
    //        UnityContainerUnderTest.LoadConfigurationFromFolder(@".\Configuration");
    //    }
    //}

    //public class UnityContainerExtensionsTests_should_load_config : UnityContainerExtensionsTests
    //{
    //    [Test]
    //    public void Check_files_are_loaded()
    //    {
    //        var logger = UnityContainerUnderTest.Resolve<ILogger>("Logger");
    //        logger.Log("message");

    //        Assert.IsInstanceOf<FileLogger>(logger);
    //    }
    //}
}
