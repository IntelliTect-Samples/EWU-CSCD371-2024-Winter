using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{

    private FileLogger? _fileLogger;
    private readonly string _Path = "Text.txt";
    [TestInitialize]
    public void Constructor()
    {
        _fileLogger = new(_Path);
    }

    [TestMethod]
    public void Log_AppendsMessage_Successful()
    {
        string message = "Hello Everybody!";
       
        if (File.Exists(_Path))
        {
            File.Delete(_Path);
        }

        FileStream MyFile = File.Create(_Path);
        MyFile.Close();
        _fileLogger!.ClassName = "Test";
        _fileLogger!.Log(LogLevel.Error, message);
        DateTime dateTime = DateTime.Now;
        StreamReader FileReader = new(_Path);
        string MessageInFile = FileReader.ReadLine() ?? string.Empty;
        FileReader.Close();
        string MessageToAppend = $"{dateTime} Test Error : {message}";

        Assert.AreEqual(MessageToAppend, MessageInFile);

        File.Delete(_Path);
    }
}
