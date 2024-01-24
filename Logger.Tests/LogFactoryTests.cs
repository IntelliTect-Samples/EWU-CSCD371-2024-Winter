using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
       
    [TestMethod]
    public void LogFactory_CreateLoggerWithClassName_ClassNameSetCorrectly()
    {
        var filePath = "test.log";
        var expectedClassName = "TestClass";
        var logger = new FileLogger(filePath) { ClassName = expectedClassName };

        Assert.IsNotNull(logger);
        Assert.AreEqual(expectedClassName, logger.ClassName);

    }
    
}
