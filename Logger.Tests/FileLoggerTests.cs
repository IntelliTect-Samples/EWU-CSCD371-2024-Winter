﻿using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NUnit.Framework.Internal;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private FileLogger? fileLogger;
    private readonly string _filePath = "text.txt";

    [TestInitialize]
    public void Constructor()
    {
        fileLogger = new FileLogger(_filePath);
    }

    [TestMethod]
    public void Log_FileCreated_Successful()
    {
        // Arrange
        var logger = new FileLogger(_filePath)
        {
            ClassName = "Test"
    };

        // Act
        logger.Log(LogLevel.Information, "Test Message");

        // Assert
        Assert.IsTrue(File.Exists(_filePath));

    }

    [TestMethod]
    public void Log_dWriteLogToFile_Successful()
    {
        // Arrange
        var logger = new FileLogger(_filePath);
        DateTime currentDate = DateTime.Now;
        string formattedDate = currentDate.ToString("MM/dd/yyyy");

        // Act
        logger.Log(LogLevel.Information, "Test message");

        // Assert
        var logContent = File.ReadAllText(_filePath);
        StringAssert.Equals(formattedDate, logContent);
        StringAssert.Equals("FileLogger", logContent);
        StringAssert.Equals(LogLevel.Information.ToString(), logContent);
        StringAssert.Equals("Test message", logContent);
    }


    [TestMethod]
    public void Log_OverwritesExistingLogFile_Successful()
    {
        // Arrange
        var logger = new FileLogger(_filePath);

        // Act
        logger.Log(LogLevel.Information, "First message");
        logger.Log(LogLevel.Warning, "Second message");

        // Assert
        var logContent = File.ReadAllText(_filePath);
        Assert.AreNotEqual("First message", logContent);
    }

}

