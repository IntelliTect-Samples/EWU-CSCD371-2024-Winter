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
    [DataRow("Message 42", "Message 42")]
    public void Error_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Error(logger, message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Checking Server Software Router", "Checking")]
    public void Error_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Error(logger, message, "Server", "Software", "Router");

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
    [DataRow("Message 42", "Message 42")]
    public void Warning_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Warning(logger, message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Checking Server Software Router", "Checking")]
    public void Warning_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Warning(logger, message, "Server", "Software", "Router");

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
    [DataRow("Message 42", "Message 42")]
    public void Information_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Information(logger, message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Checking Server Software Router", "Checking")]
    public void Information_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Information(logger, message, "Server", "Software", "Router");

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
    [DataRow("Message 42", "Message 42")]
    public void Debug_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Debug(logger, message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Checking Server Software Router", "Checking")]
    public void Debug_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        BaseLoggerMixins.Debug(logger, message, "Server", "Software", "Router");

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
