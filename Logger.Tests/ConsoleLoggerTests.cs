using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

    [TestClass]
    public class ConsoleLoggerTests{

    public StringWriter? MockConsole { get; set; }

    [TestInitialize]
    public void SetNewConsoleOut()
    {
        MockConsole = new StringWriter();
        Console.SetOut(MockConsole);
    }


    [TestMethod]
    [DataRow("FileLoggerTests Warning: Test message", LogLevel.Warning, "Test message")]
    public void Log_ValidMessage_WritesToConsoleSuccssfully(string expected, LogLevel level, string input)
    {
        ConsoleLogger logger = new();
        logger.Log(level, input);

        Assert.Equals(expected, MockConsole!.ToString());


    }

}

