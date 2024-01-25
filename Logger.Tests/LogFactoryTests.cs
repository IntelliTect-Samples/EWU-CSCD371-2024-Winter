[TestMethod]
public void LogFactory_SetClassName_Fail()
{
    LogFactory logFactory = new LogFactory();
    BaseLogger? logger = logFactory.CreateLogger("");
    if (logger != null)
    {
        Assert.AreEqual("", logger.ClassName);
    }
    else
    {
        Assert.Fail("Logger should not be null.");
    }
}

[TestMethod]
public void LogFactory_SetClassName_Success()
{
    LogFactory logFactory = new LogFactory();
    BaseLogger? logger = logFactory.CreateLogger("Logger");
    if (logger != null)
    {
        Assert.AreEqual("Logger", logger.ClassName);
    }
    else
    {
        Assert.Fail("Logger should not be null.");
    }
}
