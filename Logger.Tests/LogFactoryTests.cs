﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Configure_NullLogPath_ThrowsArgumentNullException()
    {
        LogFactory logFactory = new();
<<<<<<< HEAD
        Assert.ThrowsException<ArgumentNullException>(() => logFactory.ConfigureFileLogger(null!));
    }

}
=======
        Assert.ThrowsException<ArgumentNullException>(() => logFactory.Configure(null!));
    }

    [TestMethod]
    public void Configure_ValidPath_SetsLogFileLocation()
    {
        LogFactory logFactory = new();

        string validPath = "LogFile.txt";
        string res = logFactory.Configure(validPath);
        Assert.AreEqual(validPath, res);
    }

    [TestMethod]
    public void CreateLogger_WithNullLogPath_ReturnsNull()
    {
        LogFactory LogFactory = new();
        LogFactory.Configure(null!);
    }

}
>>>>>>> cd4cecc722f31e5a2714f61f9bb389390f3a3645
