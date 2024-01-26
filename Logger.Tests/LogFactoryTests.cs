using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private LogFactory? _LogFactory;
    [TestInitialize]
    public void Constructor()
    {
        _LogFactory = new();
    }

    [TestMethod]
    public void CreateLogger_NullReturn_Success()
    {
        Assert.AreEqual(null, _LogFactory!.CreateLogger("NotAFileLogger"));
    }

    [TestMethod]
    public void CreateLogger_CheckClassName_Success()
    {
        _LogFactory!.ConfigureFileLogger("text.txt");
        Assert.AreEqual("FileLogger", _LogFactory!.CreateLogger("FileLogger")!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_CheckClassName_Fail()
    {
        _LogFactory!.ConfigureFileLogger("text.txt");
        Assert.AreNotEqual("FileNotLogger", _LogFactory!.CreateLogger("FileLogger")!.ClassName);
    }

    [TestMethod]
    public void ConfigureFileLogger_CorrectPathName_Success()
    {
        Assert.AreEqual("text.txt", _LogFactory!.ConfigureFileLogger("text.txt"));
    }

    [TestMethod]
    public void CreateLogger_InvalidClassName_Fail()
    {
        Assert.AreEqual(null, _LogFactory!.CreateLogger("InvalidClaseName"));
    }
}
