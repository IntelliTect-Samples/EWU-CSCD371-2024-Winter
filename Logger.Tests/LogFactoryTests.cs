using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    [DataRow("/Files/Log.txt", "Logger")]
    public void ConfigureLogger_ValidPathName_ReturnsFileLogger(string pathName, string className)
    {
        // Arrange
        var logger = new LogFactory();

        //Act
        logger.ConfigureFileLogger(pathName);
        BaseLogger? fileLogger = logger.CreateLogger(className);

        //Assert
        Assert.IsNotNull(fileLogger);

    }
}
