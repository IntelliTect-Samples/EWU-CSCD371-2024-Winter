using System;
using Xunit;
using Moq;
using System.IO;

namespace CanHazFunny.Tests;

public class OutputServiceTests
{
    [Fact]
    public void DisplayJoke_ThowsArgumentNull_Success()
    {
        OutputService displayJoke = new();
        Assert.Throws<ArgumentNullException>(() => displayJoke.DisplayJoke(null!));
    }

    [Fact]
    public void DisplayJoke_JokeDisplays_Success()
    {
        MockOutput mockClass = new();
        mockClass.DisplayJoke("knok knok joke");

        Assert.Equal("knok knok joke", mockClass.GetJoke());
    }

    [Fact]
    public void DisplayJoke_ValidJoke_WritesToConsole()
    {
        // Arrange
        string joke = "Funny joke";
        OutputService jokeDisplay = new();
        StringWriter consoleOutput = new();
        Console.SetOut(consoleOutput);

        // Act
        jokeDisplay.DisplayJoke(joke);

        // Assert
        Assert.Contains(joke, consoleOutput.ToString());
    }
}

public class MockOutput : IOutJoke
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