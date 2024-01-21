﻿using System;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    public string TestPathName {get; set;}

    public FileLoggerTests(){

        string filePath = String.Join(@"\", (Environment.CurrentDirectory.Split(@"\")[..^3]));
        string path = Path.Combine(filePath, "log.txt");

        TestPathName = path;
    }

    [TestMethod]
    [DataRow("FileLoggerTests Warning: Test message", LogLevel.Warning, "Test message")]
    [DataRow("FileLoggerTests Error: FileNotFound", LogLevel.Error, "FileNotFound")]
    [DataRow("FileLoggerTests Debug: 3 Bug(s) Found", LogLevel.Debug, "3 Bug(s) Found")]
    [DataRow("FileLoggerTests Information: Software Update Applied", LogLevel.Information, "Software Update Applied")]

    public void Log_ValidMessage_WritesToFileCorrectly(string expectedContent, LogLevel level, string message)
    {

        // Arrange
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(TestPathName);
        FileLogger? fileLogger = logFactory.CreateLogger(nameof(FileLoggerTests)) as FileLogger;

        String loggedMessageWithDate = DateTime.Now.ToString() + " " + expectedContent;

        // Act
        fileLogger?.Log(level, message);
        string fileContents = File.ReadLines(TestPathName).Last();

        // Assert
         Assert.AreEqual(loggedMessageWithDate, fileContents);

    }

}
