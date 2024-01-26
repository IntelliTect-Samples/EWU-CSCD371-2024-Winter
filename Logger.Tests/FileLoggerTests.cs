﻿using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private FileLogger? _logger;
    private readonly string _Path = "Test.txt";

    // [TestInitialize]
    // public void Constructor()
    // {
    //     _logger = new(_Path);
    // }
    // [TestMethod]
    // public void log_AppendsMessage_successful()
    // {
    //     if (File.Exists(_Path))
    //     {
    //         File.Delete(_Path);
    //     }

    //     _logger!.Log(LogLevel.Error, "TESTY-TESTY-TESTY");
    //     _logger!.ClassName = "TEST";
    //     string dateTime =  DateTime.Now.ToString("MM/d/yyy hh:mm:ss tt");
    //     StreamReader FileReader = new(_Path);
    //     string MessageInFile = FileReader.ReadLine() ?? string.Empty;
    //     FileReader.Close();
    //     string MessageToAppend = $"{dateTime} TEST Error : TESTY-TESTY-TESTY";
    //     Assert.AreEqual(MessageToAppend, MessageInFile);
    //     File.Delete(_Path);
    // }
}
