using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_SetClassName_Fail()
    {
        LogFactory logFactory = new LogFactory();
        BaseLogger? logger = logFactory.CreateLogger("");
        if (logger == null)
        {
            Assert.AreEqual("", fileLogger.ClassName)
        }
    }
    [TestMethod]
    public void LogFactory_SetClassName_Success()
    {
        LogFactory logFactory = new LogFactory();
        BaseLogger? logger = logFactory.CreateLogger("Logger");
        if (logger != null)
        {
            Assert.AreEqual("Logger", fileLogger.ClassName)
        }
    }
}
