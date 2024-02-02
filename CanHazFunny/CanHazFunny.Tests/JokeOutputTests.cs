using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeOutputTests
{
    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Assertions", "xUnit2006:Do not use invalid string equality check", Justification = "As per assignment fundamentals requirements")]
    public void PrintJoke_GivenString_PrintsString()
    {
        JokeOutput jokeOutput = new();

        using StringWriter output = new();
        Console.SetOut(output);

        jokeOutput.PrintJoke("Test joke");
        Assert.Equal<string>("Test joke", output.ToString().Trim());
    }

    [Fact]
    public void PrintJoke_GivenNull_ThrowsException()
    {
        JokeOutput jokeOutput = new();

        using StringWriter output = new();
        Console.SetOut(output);

        Assert.Throws<ArgumentNullException>(() => jokeOutput.PrintJoke(null!));
    }
}
