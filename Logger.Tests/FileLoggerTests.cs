using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;
using System.Linq;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_Path_AppendToLine()
    {
        //string fileName = @"C:\file.txt";

        //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string path = string.Join(@"\", (Environment.CurrentDirectory));
        string fileName = Path.Combine(path, "file.txt");

        FileLogger fileLogger = new (fileName);
        fileLogger.Log(LogLevel.Error, "ERROR");
        string log = File.ReadLines(fileName).Last();  // Updated to string?

        //using (StreamReader sr = File.OpenText(fileName))
        //{
        //    while (!sr.EndOfStream)
        //    {
        //        log = sr.ReadLine();
        //    }
        //}
        Assert.AreEqual($"{System.DateTime.Now} {nameof(FileLoggerTests)} {LogLevel.Error}: {"ERROR"}", log);
    }
}
