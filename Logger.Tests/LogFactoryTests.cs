﻿using System;
using System.Runtime.CompilerServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void Test_ConfigureFileLogger_Good_Value(String filePath)
    {
        LogFactory factory = new LogFactory();
        factory.ConfigureFileLogger(filePath);
        factory.CreateLogger(nameof(Test_ConfigureFileLogger_Good_Value));
        Assert.IsNotNull(factory);
    }
    

}
