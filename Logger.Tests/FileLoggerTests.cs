using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void log_Path_AppendToLine()
    {
        string fileName = @"C:\file.txt";
        FileLogger fileLogger = new FileLogger(fileName);
        fileLogger.Log(LogLevel.Warning, "Warnings");
        string log;

        using(StreamReader sr = File.OpenText(fileName))
        {
            while (sr.EndOfStream)
            {
                log = sr.ReadLine();
            }
        }
        Assert.AreEqual($"{System.DateTime.Now} {"FileLoggerTests"} {LogLevel.Warning}: {"Warnings"}",  log);
    }
    

}
