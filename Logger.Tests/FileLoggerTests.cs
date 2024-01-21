using System;
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
        TestPathName = filePath;
    }

    [TestMethod]
    [DataRow("FileLoggerTests Warning: Test message", LogLevel.Warning, "Test message","log.txt")]
    [DataRow("FileLoggerTests Error: FileNotFound", LogLevel.Error, "FileNotFound", "log.txt")]
    [DataRow("FileLoggerTests Debug: 3 Bug(s) Found", LogLevel.Debug, "3 Bug(s) Found", "System.log")]
    [DataRow("FileLoggerTests Information: Software Update Applied", LogLevel.Information, "Software Update Applied", "System.log")]
    public void Log_ValidMessage_WritesToFileCorrectly(string expectedContent, LogLevel level, string message, string fileName)
    {

     
        string path = Path.Combine(TestPathName, fileName);

        // Arrange
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(path);
        FileLogger? fileLogger = logFactory.CreateLogger(nameof(FileLoggerTests)) as FileLogger;

        String loggedMessageWithDate = DateTime.Now.ToString() + " " + expectedContent;

        // Act
        fileLogger?.Log(level, message);
        string fileContents = File.ReadLines(path).Last();

        // Assert
         Assert.AreEqual(loggedMessageWithDate, fileContents);

    }

}
