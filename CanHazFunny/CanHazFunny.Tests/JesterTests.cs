using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_NormalTest_Successful()
    {
        var mockJokeToScreen = new Mock<IJokeToScreen>();
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.SetupSequence(x => x.GetJoke()).Returns("Test Joke");

        var testJester = new Jester(mockJokeService.Object, mockJokeToScreen.Object);
        testJester.TellJoke();

        Assert.Equal("Test Joke", mockJokeToScreen.Invocations[0].Arguments[0]);
    }

    [Fact]
    public void TellJoke_ChuckNorrisThenNormalTest_ReturnsNormalJoke()
    {
        var mockJokeToScreen = new Mock<IJokeToScreen>();
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.SetupSequence(x => x.GetJoke()).Returns("Chuck Norris").Returns("Test Joke");

        var testJester = new Jester(mockJokeService.Object, mockJokeToScreen.Object);
        testJester.TellJoke();

        Assert.Equal("Test Joke", mockJokeToScreen.Invocations[0].Arguments[0]);
    }

    [Fact]
    public void TellJoke_NullJokeToScreen_ThrowsException()
    {
        IJokeToScreen? nullJokeToScreen = null;
        var mockJokeService = new Mock<IJokeService>();
        Assert.Throws<ArgumentNullException>(() => new Jester(mockJokeService.Object, nullJokeToScreen!));
    }

    [Fact]
    public void TellJoke_NullJokeService_ThrowsException()
    {
        IJokeService? nullJokeService = null;
        var mockJokeToScreen = new Mock<IJokeToScreen>();
        Assert.Throws<ArgumentNullException>(() => new Jester(nullJokeService!, mockJokeToScreen.Object));
    }

}
