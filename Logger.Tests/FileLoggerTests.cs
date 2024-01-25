using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private FileLogger? Logger;

    [TestInitialize]
    public void Initialize()
    {
        Logger = new("test.txt");
    }

    [TestMethod]
    public void Log_MessageGiven_LogsMessage()
    {
        Logger!.Log(LogLevel.Information, "yo, I am testing stuff");
        string output = File.ReadAllText("test.txt");
        Assert.IsTrue(output.Contains("yo, I am testing stuff"));

        File.Delete("test.txt");
    }

}