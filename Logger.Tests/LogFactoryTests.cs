using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private LogFactory? _logFactory;
    private readonly string _filePath = "text.txt";
    [TestInitialize]
    public void Constructor()
    {
        _logFactory = new(_filePath);
    }

    [TestMethod]
    public void CreateLogger_CheckClassName_Success()
    {
        
        Assert.AreEqual("FileLogger", _logFactory!.CreateLogger("FileLogger")!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_CheckClassName_Fail()
    {
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
