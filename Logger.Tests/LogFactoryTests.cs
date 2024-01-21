using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    [DataRow("/Files/Log.txt", "Logger")]
    //if the LogFactory has been configured using ConfigureLogger
    //then it should return a FileLogger
    public void CreateLogger_ConfigurredPath_ReturnsFileLogger(string pathName, string className)
    {
        // Arrange
        var logger = new LogFactory();

        //Act
        logger.ConfigureFileLogger(pathName);
        FileLogger? fileLogger = logger.CreateLogger(className) as FileLogger;

        //Assert
        Assert.IsNotNull(fileLogger);

    }
}
