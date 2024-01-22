using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{

    public LogFactory LogFactory {get; set;}

    public LogFactoryTests() {
        //Arrange
        LogFactory = new LogFactory();
    }


    [TestMethod]
    public void CreateLogger_UnconfigurredPath_ReturnsNull()
    {
        //Act
        FileLogger? fileLogger = LogFactory.CreateLogger(nameof(LogFactory)) as FileLogger;
        //Assert
        Assert.IsNull(fileLogger);

    }

    [TestMethod]
    [DataRow("/Files/Log.txt")]
    public void CreateLogger_ConfigurredPath_ReturnsFileLogger(string pathName)
    {

        //Act
        LogFactory.ConfigureFileLogger(pathName);
        FileLogger? fileLogger = LogFactory.CreateLogger(nameof(LogFactory)) as FileLogger;

        //Assert
        Assert.IsNotNull(fileLogger);

    }
}
