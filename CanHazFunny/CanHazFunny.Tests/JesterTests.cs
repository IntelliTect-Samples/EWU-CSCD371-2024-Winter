using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;

public class JesterTests
{
    private Mock<IJokeService> JokeServiceMock { get; }
    private Mock<IJokeOutput> JokeOutputMock { get; set; }
    private readonly Jester _jesterInstance;
    public JesterTests()
    {
        JokeServiceMock = new Mock<IJokeService>();
        JokeOutputMock = new Mock<IJokeOutput>();
        _jesterInstance = new Jester(JokeOutputMock.Object, JokeServiceMock.Object);
    }

    [Fact]
    public void Jester_NullJokeService_ThrowsException()
    {
        Exception exception = Assert.Throws<ArgumentNullException>(() => new Jester(JokeOutputMock.Object, null!));
    }

    [Fact]
    public void Jester_NullJokeOutput_ThrowsException()
    {
        Exception exception = Assert.Throws<ArgumentNullException>(() => new Jester(null!, JokeServiceMock.Object));

    }

    [Fact]
    public void TellJoke_NotChuckNorrisJoke_Print()
    {
        string regularJoke = "Regular joke";
        JokeServiceMock?.Setup(js => js.GetJoke()).Returns(regularJoke);

        _jesterInstance.TellJoke();

        JokeOutputMock?.Verify(co => co.PrintJoke(regularJoke), Times.Once);
    }

    [Fact]
    public void TellJoke_ChuckNorrisJoke_SkipFirstThenPrint()
    {
        string chuckNorrisJoke = "Chuck Norris joke";
        string regularJoke = "Regular joke";
        int callCount = 0;
        JokeServiceMock?.Setup(js => js.GetJoke()).Returns(() => callCount++ == 0 ? chuckNorrisJoke : regularJoke);

        _jesterInstance.TellJoke();

        JokeOutputMock?.Verify(co => co.PrintJoke(regularJoke), Times.Once);

    }
}
