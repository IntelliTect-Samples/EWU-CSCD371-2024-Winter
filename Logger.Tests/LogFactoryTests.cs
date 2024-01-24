using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Configure_NullLogPath_ThrowsArgumentNullException()
    {
        var logFactory = new LogFactory();
        Assert.ThrowsException<ArgumentNullException>(() => logFactory.Configure(null!));
    }

    [TestMethod]
    public void Configure_ValidPath_SetsLogFileLocation()
    {
        var logFactory = new LogFactory();

        string validPath = "LogFile.txt";
        string res = logFactory.Configure(validPath);
        Assert.AreEqual(validPath, res);
    }

}
