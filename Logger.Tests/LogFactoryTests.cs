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
        _logFactory.ConfigureFileLogger("Test.txt");
        _logger = _logFactory.CreateLogger("Test");
    }

    [TestMethod]
    public void ConfigureFileLogger_GoodFilePath_Successful()
    {
        Assert.AreEqual("Test.txt",_logFactory!.GetFileName());
    }

}
