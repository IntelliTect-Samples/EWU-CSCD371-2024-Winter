using System;
using Xunit;
using Moq;
using System.IO;

namespace CanHazFunny.Tests;

public class JokeOutputTests
{

    //public JokeOutputTests()
    //{
    //    JokeOutput jokePrint = new();
    //}

    //[Theory]
    //[inlineData("JOKE1")]
    //[inlineData ("JOKE2")]
    //public void PrintingJoke_OutputToConsole_Success(string output)
    //{
    //    JokeOutput jokePrint = new();
    //    jokePrint.PrintingJoke(output);

    //    //Mock mockConsole = new < IConsoleWrapper > ();
    //    //string outputString =  mockConsole.WriteLine();

    //}
    [Fact]
    public void PrintingJoke_ConsolePrintingNull_ThrowNull_Fail()
    {
        bool exceptionThrown = false;
        try
        {
            JokeOutput output = new();
            using StringWriter sw = new();
            Console.SetOut(sw);
            output.PrintingJoke(null!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }
        Assert.True(exceptionThrown);
    }
    [Fact]
    public void PrintingJoke_ConsolePrinting_Successful()
    {
        JokeOutput output = new();
        string jokey = "Chuck Norris";
        using StringWriter sw = new();
        Console.SetOut(sw);
        output.PrintingJoke(jokey);
        Assert.NotEqual(jokey, sw.ToString());
    }
    
}
//public interface IConsoleWrapper
//{
//    void WriteLine(string value);
//}
