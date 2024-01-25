using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_Path_AppendToLine()
    {
        // Define the file path for the log
        string fileName = @"C:\file.txt";  // Consider using a path that is not system-specific
        FileLogger fileLogger = new FileLogger(fileName);
        fileLogger.Log(LogLevel.Warning, "Warnings");
        
        // Initialize 'log' to null
        string log = null;

        // Read from the file
        using (StreamReader sr = File.OpenText(fileName))
        {
            while (!sr.EndOfStream)  // Ensure it reads until the end of the stream
            {
                log = sr.ReadLine();  // Read each line from the stream
            }
        }

         Assert.AreEqual($"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} {"FileLoggerTests"} {LogLevel.Warning}: {"Warnings"}", log);
    }
}
