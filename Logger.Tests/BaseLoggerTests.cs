using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerTests()
{
    [TestMethod]
    public void AutoProperty_SetClassNameToNull_Success()
    {
        MockClass MockClass = new();
        Assert.AreEqual(null, MockClass.ClassName);
    }

    [TestMethod]
    public void AutoProperty_SetClassNameToClassName_Success()
    {
        MockClass MockClass = new() { ClassName = "FileLogger"};
        Assert.AreEqual(nameof(FileLogger), MockClass.ClassName);
    }
}

public class MockClass : BaseLogger
{
    public override void Log(LogLevel logLevel, string message)
    {
        throw new NotImplementedException();
    }
}

