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

<<<<<<< HEAD
   

}
=======

}
>>>>>>> cd4cecc722f31e5a2714f61f9bb389390f3a3645
