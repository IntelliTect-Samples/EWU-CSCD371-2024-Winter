using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLoggerLog_AppendMessageToFile_SuccessfullyAppended()
    {
        //create test path and test message
        string testPath = "testFile.txt";
        string testMessage = "Test Message";

        //create file Logger
        BaseLogger fileLogger = new FileLogger(testPath);

        //set message by calling fileLoggers log method
        fileLogger.Log(LogLevel.Warning, testMessage);

        //test if file contains all except time/date since date is set Log function
        Assert.IsTrue(File.ReadAllText(testPath).Contains($"FileLogger Warning: Test Message"));
    }

}