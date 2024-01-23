using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private FileLogger? _logger;

    [TestInitialize]
    public void Initialize()
    {
        _logger = new("log.txt");
    }

    [TestMethod]
    public void Log_MessageGiven_LogsMessage()
    {
        _logger!.Log(LogLevel.Information, "test");
        string output = File.ReadAllText("log.txt");
        Assert.IsTrue(output.Contains("test"));

        File.Delete("log.txt");
    }

    [TestMethod]
    public void Log_EmptyMessage_NoMessage()
    {
        _logger!.Log(LogLevel.Information, "");
        string output = File.ReadAllText("log.txt");
        Assert.IsFalse(output.Contains("test"));

        File.Delete("log.txt");
    }
}
