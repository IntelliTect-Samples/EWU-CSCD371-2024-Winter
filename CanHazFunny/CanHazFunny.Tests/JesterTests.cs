using Moq;
using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    private readonly Mock<IJokeService>? _jokeServiceMock;
    private readonly Mock<IOutputService>? _mockConsoleOutput;
    private readonly Jester _jester;

    public JesterTests()
    {
        _jokeServiceMock = new Mock<IJokeService>();
        _mockConsoleOutput = new Mock<IOutputService>();
        _jester = new Jester(_jokeServiceMock.Object, _mockConsoleOutput.Object);
    }

    [Fact]
    public void TellJoke_SkipChuckNorris_PrintNormal()
    {
        var chuckNorrisJoke = "Chuck Norris hehe";
        var regularJoke = "Regular Joke";
        var callCount = 0;
        _jokeServiceMock?.Setup(js => js.GetJoke()).Returns(() => callCount++ == 0 ? chuckNorrisJoke : regularJoke);

        _jester.TellJoke();

        _mockConsoleOutput?.Verify(co => co.WriteJoke(regularJoke), Times.Once);

    }

    [Fact]
    public void TellJoke_WritesNonChuckNorris_PrintNormal()
    {
        var regularJoke = "Regular hehe";
        _jokeServiceMock?.Setup(js => js.GetJoke()).Returns(regularJoke);

        _jester.TellJoke();

        _mockConsoleOutput?.Verify(co => co.WriteJoke(regularJoke), Times.Once);
    }

    [Fact]
    public void Jester_NullIJokeService_ThrowsException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(null, _mockConsoleOutput?.Object));
        Assert.Equal("jokeService", exception.ParamName);
    }

    [Fact]
    public void Jester_NullOutputService_ThrowsException()
{
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(_jokeServiceMock?.Object, null));
        Assert.Equal("outputService", exception?.ParamName);
    
}
}
