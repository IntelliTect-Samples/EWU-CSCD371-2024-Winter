using System;
using Xunit;
using Moq;

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

    [Fact]
    public void TellJoke_RetriveAJoke_Success()
    {
        //var mock = new Mock<IJokeService>();
        //mock.Setup(x => x.GetJoke()).Returns("Not a funny joke");
        //IJokeService mockService = mock.Object;
        //Jester jester = new(mock.Object, new OutputService());
        //Assert.Equal("Not a funny joke", jester.TellJoke());

    }
}
