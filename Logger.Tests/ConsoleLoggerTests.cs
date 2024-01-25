using System;
using System.Globalization;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

    [TestClass]
    public class ConsoleLoggerTests{

    public StringWriter? MockConsole { get; set; }
    public ConsoleLogger? Logger { get; set; }

    [TestInitialize]
    public void SetNewConsoleOut()
    {
        Logger = new() { ClassName = nameof(ConsoleLoggerTests) };
        MockConsole = new StringWriter();
        Console.SetOut(MockConsole);
    }


    [TestMethod]
    [DataRow("ConsoleLoggerTests Warning: Test message", LogLevel.Warning, "Test message")]
    [DataRow("ConsoleLoggerTests Error: Test Error", LogLevel.Error, "Test Error")]

    public void Log_ValidMessage_WritesToConsoleSuccssfully(string expected, LogLevel level, string input)
    {
        // Arrange
        string expectedMessageWithDate = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} {expected}{Environment.NewLine}";

        // Act
        Logger!.Log(level, input);

        // Assert
        Assert.AreEqual(expectedMessageWithDate, MockConsole!.ToString());

    }

}

