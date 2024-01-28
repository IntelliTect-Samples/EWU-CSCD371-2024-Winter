using System;
using Xunit;

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