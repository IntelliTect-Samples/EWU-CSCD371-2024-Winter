using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLogger_WithConfiguredFileLogger_ReturnsFileLoggerInstance()
    {
        var logger = new LogFactory();
        string filePath = "TestLogFile.txt";
        logFactory.ConfigureFileLogger(filePath);

        //Act
        var logger = LogFactory.CreateLogger("ExampleClass");
        
        //Assert
        Assert.IsNotNull(logger);
        Assert.IsInstanceOfType(logger, typeof(FileLogger));
    }
    
    [TestMethod]
    public void CreateLogger_WithoutConfiguredFileLogger_ReturnsNull()
    {
        //Arrange
        var logFactory = new LogFactory();

        //Act
        var logger = logFactory.CreateLogger("ExampleClass");

        //Asssert
        Assert.IsNull(logger);
    }
}
