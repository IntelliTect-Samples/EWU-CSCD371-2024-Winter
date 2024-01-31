using System;
using Xunit;
using System.IO;

namespace CanHazFunny.Tests;

public class OutputServiceTests
{
    [Fact]
    public void DisplayJoke_ThrowsArgumentNull_Success()
    {
        OutputService displayJoke = new();
        Assert.Throws<ArgumentNullException>(() => displayJoke.DisplayJoke(null!));
    }

    [Fact]
    public void DisplayJoke_JokeDisplays_Success()
    {
        MockOutput mockClass = new();
        mockClass.DisplayJoke("knock knock joke");

        Assert.Equal("knock knock joke", mockClass.GetJoke());
    }

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

public class MockOutput : IOutputService
{
    private string? Joke { get; set; }

    public void DisplayJoke(string joke)
    {
        Joke = joke;
    }

    public string GetJoke()
    {
        return Joke!;
    }
}
