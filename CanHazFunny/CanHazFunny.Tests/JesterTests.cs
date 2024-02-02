using System;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace CanHazFunny.Tests;

public class JesterTests
{

    [Fact]
    public void IJokeServiceProperty_SetPropertyToNull_ThrowsNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Jester(null!, new OutputService()));
    }

    [Fact]
    public void IOutServiceProperty_SetPropertyToNull_ThrowsNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Jester(new JokeService(), null!));
    }

    [Fact]
    public void IJokeServiceProperty_SetProperty_Success()
    {
        JokeService jokeService = new();
        OutputService outputService = new();
        Jester jester = new(jokeService, outputService);
        Assert.Equal<IJokeService>(jokeService, jester.JokeService);
    }

    [Fact]
    public void IOutServiceProperty_SetProperty_Success()
    {
        JokeService jokeService = new();
        OutputService outputService = new();
        Jester jester = new(jokeService, outputService);
        Assert.Equal<IOutputService>(outputService, jester.OutputService);
    }

    [Fact]
    public void TellJoke_DisplayCorrectJoke_Success()
    {
        // Arrange
        string joke = "It was such a good joke";
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.Setup(x => x.GetJoke()).Returns(joke);
        var mockOutService = new Mock<IOutputService>();
        Jester jester = new(mockJokeService.Object, mockOutService.Object);

        // Act
        jester.TellJoke();

        // Assert
        mockOutService.Verify(x => x.DisplayJoke(joke));
    }

    [Fact]
    public void TellJoke_SkipsChuckNorrisJokes_Success()
    {
        // Arrange
        var jokeServiceMock = new Mock<IJokeService>();
        var outServiceMock = new Mock<IOutputService>();

        var jokes = new Queue<string>();
        jokes.Enqueue("Chuck Norris can divide by zero.");
        jokes.Enqueue("A normal joke.");

        jokeServiceMock.Setup(js => js.GetJoke()).Returns(jokes.Dequeue);

        var jester = new Jester(jokeServiceMock.Object, outServiceMock.Object);

        // Act
        jester.TellJoke();

        // Assert
        outServiceMock.Verify(x => x.DisplayJoke("A normal joke."), Times.Once);
    }
}
