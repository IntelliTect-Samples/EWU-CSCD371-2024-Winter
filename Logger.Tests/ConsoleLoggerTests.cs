using System;
using System.Globalization;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

    [TestClass]
    public class ConsoleLoggerTests{

    public StringWriter? MockConsole { get; set; }
    public StringBuilder? MockConsoleText { get; set; }

    [TestInitialize]
    public void SetNewConsoleOut()
    {
        MockConsoleText = new StringBuilder();
        MockConsole = new StringWriter(MockConsoleText!);
        Console.SetOut(MockConsole);
    }


    [TestMethod]
    [DataRow("ConsoleLoggerTests Warning: Test message", LogLevel.Warning, "Test message")]
    [DataRow("ConsoleLoggerTests Error: Test Error", LogLevel.Error, "Test Error")]

    public void Log_ValidMessage_WritesToConsoleSuccssfully(string expected, LogLevel level, string input)
    {
        ConsoleLogger logger = new() { ClassName = nameof(ConsoleLoggerTests)};
        logger.Log(level, input);

        string expectedMessageWithDate = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} {expected}{Environment.NewLine}";

        Assert.AreEqual(expectedMessageWithDate, MockConsole!.ToString());


    }

}

