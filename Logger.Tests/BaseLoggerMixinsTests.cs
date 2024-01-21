using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Error_WithNullLogger_ThrowsException()
    {

        // Act
        BaseLoggerMixins.Error(null, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42", null)]
    [DataRow("Checking Server Software Router", "Checking", new string[] { "Server", "Software", "Router" })]
    public void Error_WithData_LogsMessage(string expectedMessage, string message, params string[] arguments)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Error(logger, message, arguments);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {

        // Act
        BaseLoggerMixins.Warning(null, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42", null)]
    [DataRow("Checking Server Software Router", "Checking", new string[] { "Server", "Software", "Router" })]
    public void Warning_WithData_LogsMessage(string expectedMessage, string message, params string[] arguments)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Warning(logger, message, arguments);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Information_WithNullLogger_ThrowsException()
    {

        // Act
        BaseLoggerMixins.Information(null, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42", null)]
    [DataRow("Checking Server Software Router", "Checking", new string[] { "Server", "Software", "Router" })]
    public void Information_WithData_LogsMessage(string expectedMessage, string message, params string[] arguments)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Information(logger, message, arguments);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Debug_WithNullLogger_ThrowsException()
    {

        // Act
        BaseLoggerMixins.Debug(null, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42", null)]
    [DataRow("Checking Server Software Router", "Checking", new string[] { "Server", "Software", "Router" })]
    public void Debug_WithData_LogsMessage(string expectedMessage, string message, params string[] arguments)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Debug(logger, message, arguments);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }
}

public class TestLogger : BaseLogger
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}
