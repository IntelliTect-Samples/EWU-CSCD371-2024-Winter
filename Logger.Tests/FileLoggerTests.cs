using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_ValidInput_LogsMessageToFile()
    {
        //Arrange 
        string filePath = "TestLogFile.txt";
        var logger = new FileLogger(filePath);

        // Act 
        logger.Log(LogLevel.Information, "Test message");

        //Assert
        Assert.IsTrue(File.Exists(filePath));
    }

    [TestMethod]
    public void Log_NullMessage_ThrowsException()
    {
        //Arrange
        string filePath = "TestLogFile.txt";
        var logger = new FileLogger(filePath);

        //Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() => logger.Log(LogLevel.Information, null));

    }
}