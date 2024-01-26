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
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Error(null!, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42")]
    public void Error_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger!.Error(message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Intellij is installed on computer number 468 at Alpha Station", "{0} is installed on computer number {1} at {2} Station")]
    public void Error_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger!.Error(message, "Intellij", "468", "Alpha");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Warning(null!, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42")]
    public void Warning_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Warning(message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Intellij is installed on computer number 468 at Alpha Station", "{0} is installed on computer number {1} at {2} Station")]
    public void Warning_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Warning(message, "Intellij", "468", "Alpha");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Information_WithNullLogger_ThrowsException()
    {

        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Information(null!, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42")]
    public void Information_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Information(message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Intellij is installed on computer number 468 at Alpha Station", "{0} is installed on computer number {1} at {2} Station")]
    public void Information_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Information(message, "Intellij", "468", "Alpha");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Debug_WithNullLogger_ThrowsException()
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Debug(null!, "");

    }

    [TestMethod]
    [DataRow("Message 42", "Message 42")]
    public void Debug_WithDataNoArguments_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Debug(message);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(expectedMessage, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow("Intellij is installed on computer number 468 at Alpha Station", "{0} is installed on computer number {1} at {2} Station")]
    public void Debug_WithDataWithParams_LogsMessage(string expectedMessage, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Debug(message, "Intellij", "468", "Alpha");

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
