﻿using System;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    [TestMethod]
    [DataRow("ClassName Warning: Test message", LogLevel.Warning, "@FakePath", "Logger", "Test message" )]
    public void Log_ValidMessage_WritesToFileCorrectly(string expectedContent, LogLevel level, string pathname, string className, string message)
    {

        string filePath = String.Join(@"\", (Environment.CurrentDirectory.Split(@"\")[..^3]));
        String path = Path.Combine(filePath, "log.txt");


        // Arrange
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(path);
        FileLogger? fileLogger = logFactory.CreateLogger(className) as FileLogger;

        String trueLoggedMessage = DateTime.Now.ToString() + " " + expectedContent;

        // Act
        fileLogger?.Log(level, message);
        string fileContents = File.ReadAllText(path);

        // Assert
         Assert.AreEqual(trueLoggedMessage, fileContents);

    }

}
