using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    public BaseLogger? MockFileLogger { get; set; }

    [TestInitialize]
    public void SetMockLogger()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(GetFilePath());
        MockFileLogger = logFactory.CreateLogger(nameof(FileLoggerTests))!;
    }


    [TestMethod]
    [DataRow("FileLoggerTests Warning: Test message", LogLevel.Warning, "Test message")]
    [DataRow("FileLoggerTests Error: FileNotFound", LogLevel.Error, "FileNotFound")]
    [DataRow("FileLoggerTests Debug: 3 Bug(s) Found", LogLevel.Debug, "3 Bug(s) Found")]
    [DataRow("FileLoggerTests Information: Software Update Applied", LogLevel.Information, "Software Update Applied")]
    public void Log_ValidMessage_WritesToFileCorrectly(string expectedContent, LogLevel level, string message)
    {

        // Arrange
        string loggedMessageWithDate = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} {expectedContent}";

        // Act
        MockFileLogger!.Log(level, message);
        string fileContents = File.ReadLines(GetFilePath()).Last();

        // Assert
        Assert.AreEqual(loggedMessageWithDate, fileContents);

    }

    public static string GetFilePath()
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "log.txt");
        return path;
    }

    [TestCleanup]
    public void Cleanup() { 
        if(File.Exists(GetFilePath())) File.Delete(GetFilePath());
    }

}
