using System;
using Xunit;
using System.IO;

namespace CanHazFunny.Tests;

public class OutputServiceTests
{

    [Fact]
    public void DisplayJoke_ValidJoke_WritesToConsole()
    {
        // Arrange
        string joke = "Funny joke";
        OutputService jokeDisplay = new();
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        // Act
        jokeDisplay.DisplayJoke(joke);

        // Assert
        Assert.Contains(joke, stringWriter.ToString());
    }
}
