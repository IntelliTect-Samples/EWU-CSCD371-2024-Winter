using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;  // Add this line

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_Path_AppendToLine()
    {
        string fileName = @"C:\file.txt";
        FileLogger fileLogger = new FileLogger(fileName);
        fileLogger.Log(LogLevel.Warning, "Warnings");
        string log = null;  // Initialize 'log' to null

        using (StreamReader sr = File.OpenText(fileName))
        {
            while (!sr.EndOfStream)  // Change 'while (sr.EndOfStream)' to 'while (!sr.EndOfStream)'
            {
                log = sr.ReadLine();
            }
        }
        Assert.AreEqual($"{System.DateTime.Now} {"FileLoggerTests"} {LogLevel.Warning}: {"Warnings"}", log);
    }
}
