using System;
using System.Globalization;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    [TestMethod]
    [DataRow("FileLoggerTests Warning: Test message", LogLevel.Warning, "Test message","log.txt")]
    [DataRow("FileLoggerTests Error: FileNotFound", LogLevel.Error, "FileNotFound", "log.txt")]
    [DataRow("FileLoggerTests Debug: 3 Bug(s) Found", LogLevel.Debug, "3 Bug(s) Found", "System.log")]
    [DataRow("FileLoggerTests Information: Software Update Applied", LogLevel.Information, "Software Update Applied", "System.log")]
    public void Log_ValidMessage_WritesToFileCorrectly(string expectedContent, LogLevel level, string message, string fileName)
    {

        // Arrange
        MockFileLogger fileLogger = new(fileName); 
        string loggedMessageWithDate = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} {expectedContent}";

        // Act
        fileLogger.Log(level, message);
        string fileContents = File.ReadLines(GetCorrectPath(fileName)).Last();

        // Assert
        Assert.AreEqual(loggedMessageWithDate, fileContents);

    }

    public static string GetCorrectPath(string fileName)
    {
        string filePath = string.Join(@"\", (Environment.CurrentDirectory));
        string path = Path.Combine(filePath, fileName);
        return path;
    }

    public class MockFileLogger : FileLogger
    {

        public MockFileLogger(string fileName) : base(GetCorrectPath(fileName))
        {
            ClassName = nameof(FileLoggerTests);
        }

    }

}
