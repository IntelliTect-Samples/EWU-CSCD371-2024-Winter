using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Configure_NullLogPath_ThrowsArgumentNullException()
    {
        LogFactory logFactory = new();
        Assert.ThrowsException<ArgumentNullException>(() => logFactory.ConfigureFileLogger(null!));
    }

    [TestMethod]
    public void CreateLogger_NoConfiguredFileLogger_ReturnsNull()
    {
        LogFactory LogFactory = new();
        BaseLogger? logger = LogFactory.CreateLogger(nameof(LogFactoryTests));
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void CreateLogger_ConfiguredFileLogger_ReturnsFileLogger()
    {
        LogFactory logFactory = new();
        string loggerName = nameof(LogFactoryTests);

        logFactory.ConfigureFileLogger("path/to/logfile.txt");
        BaseLogger? logger = logFactory.CreateLogger(loggerName);

        Assert.IsNotNull(logger);
        Assert.IsInstanceOfType(logger, typeof(FileLogger));
    }

}
