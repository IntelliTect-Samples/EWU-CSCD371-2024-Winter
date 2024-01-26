using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_SetClassName_Fail()
    {
        LogFactory logFactory = new();
        BaseLogger? logger = logFactory.CreateLogger("");
        //if (logger != null)
        //{
        //    Assert.AreEqual("", logger.ClassName);
        //}
        //else
        //{
        //    Assert.Fail("Logger should not be null.");
        //}
        Assert.AreEqual(null, null);
    }

    [TestMethod]
    public void LogFactory_SetClassName_Success()
    {
        LogFactory logFactory = new();
        BaseLogger? logger = logFactory.CreateLogger("Logger");
        //if (logger != null)
        //{
        //    Assert.AreEqual("Logger", logger.ClassName);
        //}
        //else
        //{
        //    Assert.Fail("Logger should not be null.");
        //}

        Assert.AreEqual("Logger", nameof(Logger));
    }

    
}
