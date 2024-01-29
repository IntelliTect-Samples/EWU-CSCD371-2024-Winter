using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.Globalization;
using System.IO;

namespace CanHazFunny.Tests;

public class JokeToScreenTests
{
    [Fact]
    public void PrintJoke_OutputsJoke_Successful()
    {
        JokeToScreen jokeToScreen = new();
        StringWriter stringWriter = new(CultureInfo.InvariantCulture);
        Console.SetOut(stringWriter);
        jokeToScreen.PrintJoke("Test Joke");
        string consoleOutput = stringWriter!.ToString();

        Assert.Equal("Test Joke" + Environment.NewLine, consoleOutput);
    }

    [Fact]
    public void PrintJoke_OutputsNull_ThrowsException()
    {
        JokeToScreen jokeToScreen = new JokeToScreen();
        Assert.Throws<ArgumentNullException>(() => jokeToScreen.PrintJoke(null!));
    }
}
