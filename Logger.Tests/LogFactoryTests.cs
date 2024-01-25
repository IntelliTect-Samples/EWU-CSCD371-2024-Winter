using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private LogFactory? _logFactory;
    private BaseLogger? _logger;
    [TestInitialize]
    public void Constructor()
    {
        _logFactory = new();
    }

    [TestMethod]
    public void ConfigureFileLogger_GoodFilePath_Successful()
    {
        _logFactory!.ConfigureFileLogger("Test.txt");
        _logger = _logFactory.CreateLogger("Test");
        Assert.AreEqual("Test.txt",_logFactory!.GetFileName());
    }
    [TestMethod]
    public void CreateLogger_NoPathConfigured_ReturnsNull()
    {
        _logger = _logFactory!.CreateLogger("Test");
        Assert.IsNull(_logger);
    }

}
