using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    // [********************** Error TESTS **********************]
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Error_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Error("", null);

        // Assert
    }

    // [TestMethod]
    // public void Error_WithData_LogsMessage()
    // {
    //     // Arrange
    //     var logger = new TestLogger();

    //     // Act
    //     logger.Error("Message 42", 42);

    //     // Assert
    //     Assert.AreEqual(1, logger.LoggedMessages.Count);
    //     Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
    //     Assert.AreEqual("Message 01", logger.LoggedMessages[0].Message);
    // }

    // [********************************************************]

    // [********************** Warning TESTS **********************]
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Warning("", null);

        // Assert
    }


    // public void Warning_WithData_LogsMessage()
    // {
    //     // Arrange
    //     var logger = new TestLogger();

    //     // Act
    //     logger.Warning("Message {0}", 42);

    //     // Assert
    //     Assert.AreEqual(1, logger.LoggedMessages.Count);
    //     Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
    //     Assert.AreEqual("Message 02", logger.LoggedMessages[0].Message);
    // }
    // [********************************************************]

    // [**********************Information TESTS **********************]
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Information_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Information("", null);

        // Assert
    }


    // public void Information_WithData_LogsMessage()
    // {
    //     // Arrange
    //     var logger = new TestLogger();

    //     // Act
    //     logger.Information("Message {0}", 42);

    //     // Assert
    //     Assert.AreEqual(1, logger.LoggedMessages.Count);
    //     Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
    //     Assert.AreEqual("Message 03", logger.LoggedMessages[0].Message);
    // }
    // [********************************************************]

    // [**********************Debug TESTS **********************]
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Debug_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Debug("", null);

        // Assert
    }


    // public void Debug_WithData_LogsMessage()
    // {
    //     // Arrange
    //     var logger = new TestLogger();

    //     // Act
    //     logger.Debug("Message {0}", 42);

    //     // Assert
    //     Assert.AreEqual(1, logger.LoggedMessages.Count);
    //     Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
    //     Assert.AreEqual("Message 04", logger.LoggedMessages[0].Message);
    // }
    // [********************************************************]
}

public class TestLogger : BaseLogger
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}
