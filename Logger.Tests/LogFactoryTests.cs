using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
        var logger = logFactory.CreateLogger(expectedClassName);
    [TestMethod]
    public void LogFactory_CreateLoggerWithClassName_ClassNameSetCorrectly()
    {
        var logFactory = new LogFactory();
        var expectedClassName = "TestClass";

        Assert.IsNotNull(logger);
        Assert.AreEqual(expectedClassName, logger.ClassName);

    }
    
}
