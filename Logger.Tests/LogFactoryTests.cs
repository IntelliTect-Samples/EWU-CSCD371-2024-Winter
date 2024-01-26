using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private LogFactory? _logFactory;
    [TestInitialize]
    public void Constructor()
    {
        _logFactory = new();
    }

    [TestMethod]
    public void CreateLogger_NullReturn_Success()
    {
        Assert.AreEqual(null, _logFactory!.CreateLogger("NotAFileLogger"));
    }

    [TestMethod]
    public void CreateLogger_CheckClassName_Success()
    {
        _logFactory!.ConfigureFileLogger("text.txt");
        Assert.AreEqual("FileLogger", _logFactory!.CreateLogger("FileLogger")!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_CheckClassName_Fail()
    {
        _logFactory!.ConfigureFileLogger("text.txt");
        Assert.AreNotEqual("FileNotLogger", _logFactory!.CreateLogger("FileLogger")!.ClassName);
    }

    [TestMethod]
    public void ConfigureFileLogger_CorrectPathName_Success()
    {
        Assert.AreEqual("text.txt", _logFactory!.ConfigureFileLogger("text.txt"));
    }

    [TestMethod]
    public void CreateLogger_InvalidClassName_Fail()
    {
        Assert.AreEqual(null, _logFactory!.CreateLogger("InvalidClaseName"));
    }
}
