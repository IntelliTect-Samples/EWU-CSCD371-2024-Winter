using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLoggerObject_WithValidPath_LoggerSuccessfullyCreated()
    {
        //test for making for auto property/object intialization 
        
        //create logFactory object
        LogFactory logFactory = new();

        //make pathName value to input
        string pathName = "TestPath.txt";
        
        //create logger with path 
        logFactory.ConfigureFileLogger(pathName);

        //mkae sure logger is not null and has classname
        Assert.IsNotNull(logFactory.createLogger());
        //Assert.AreEqual(pathName, logFactory.path); 
        //path needed to be private so this won't work as it
    }

    [TestMethod]
    public void CreateLoggerObject_WithInvalidPath_ReturnsNull()
    {
        //test for when configure file logger is not called or path is null (should return null) 
        
        //create logFactory object
        LogFactory logFactory = new();

        //Make sure null is returned
        Assert.IsNull(logFactory.createLogger());
    }

}