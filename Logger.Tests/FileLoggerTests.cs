using System;
using System.IO;


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    [TestMethod]
    [DataRow("10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message", LogLevel.Warning, "@FakePath", "Logger", "Test message" )]
    public void Log_ValidMessage_WritesToFileCorrectly(string expectedContent, LogLevel level, string pathname, string className, string message)
    {
        // Arrange
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(pathname);
        FileLogger? fileLogger = logFactory.CreateLogger(className) as FileLogger;

        // Act
        fileLogger?.Log(level, message);
        string fileContents = File.ReadAllText(pathname);

        // Assert
        Assert.AreEqual(expectedContent, fileContents);

    }

}
