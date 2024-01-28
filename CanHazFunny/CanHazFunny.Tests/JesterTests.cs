using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{

    [Fact]
    public void IJokeServiceProperty_SetPorpertyToNull_Success()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Jester(null!, new OutputService()));
    }

    [Fact]
    public void IOutServiceProperty_SetPorpertyToNull_Success()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Jester(new JokeService(), null!));
    }

    [Fact]
    public void IJokeServiceProperty_SetPorperty_Success()
    {
        JokeService jokeService = new();
        OutputService outputService = new();
        Jester jester = new(jokeService, outputService);
        Assert.Equal<IJokeService>(jokeService, jester.JokeService);
    }

    [Fact]
    public void IOutServiceProperty_SetPorperty_Success()
    {
        JokeService jokeService = new();
        OutputService outputService = new();
        Jester jester = new(jokeService, outputService);
        Assert.Equal<IOutJoke>(outputService, jester.OutService);
    }
}
