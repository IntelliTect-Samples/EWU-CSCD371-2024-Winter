﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{

    public LogFactory LogFactory {get; set;}

    public LogFactoryTests() {
        //Arrange
        LogFactory = new LogFactory();
    }


    [TestMethod]
    [DataRow("Logger")]
    //if the LogFactory has been not been configured, CreateLogger should
    //return null
    public void CreateLogger_UnconfigurredPath_ReturnsFileLogger(string className)
    {
        //Act
        FileLogger? fileLogger = LogFactory.CreateLogger(className) as FileLogger;

        //Assert
        Assert.IsNull(fileLogger);

    }

    [TestMethod]
    [DataRow("/Files/Log.txt", "Logger")]
    //if the LogFactory has been configured using ConfigureLogger
    //then it should return a FileLogger
    public void CreateLogger_ConfigurredPath_ReturnsFileLogger(string pathName, string className)
    {

        //Act
        LogFactory.ConfigureFileLogger(pathName);
        FileLogger? fileLogger = LogFactory.CreateLogger(className) as FileLogger;

        //Assert
        Assert.IsNotNull(fileLogger);

    }
}
