using Xunit;
using System;
using System.IO;

namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void WriteLine_ValidInput_Success()
    {
        string testString = "test string";

        using StringWriter writer = new();
        Console.SetOut(writer);

        Program program = new();
        program.WriteLine(testString);

        Assert.Equal(testString + Environment.NewLine, writer.ToString());
    }

    [Fact]
    public void ReadLine_ValidInput_Success()
    {
        string testString = "test string";

        using StringReader reader = new(testString);
        Console.SetIn(reader);

        Program program = new();
        string result = program.ReadLine();

        Assert.Equal(testString, result);
    }

    [Fact]
    public void ReadLine_NoInput_Fails()
    {
        using StringReader reader = new("");
        Console.SetIn(reader);

        Program program = new();
        string result = program.ReadLine();

        Assert.Null(result);
    }
}