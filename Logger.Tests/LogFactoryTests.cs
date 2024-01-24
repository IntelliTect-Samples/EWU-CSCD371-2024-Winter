using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Configure_NullLogPath_ThrowsArgumentNullException()
    {
        LogFactory logFactory = new LogFactory();
        Assert.ThrowsException<ArgumentNullException>(() => logFactory.Configure(null!));
    }
}
