using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;
public class JesterTests
{

    private readonly Mock<IJokeService> JokeServiceMock;
    private readonly Mock<IJokeOutput> JokeOutputMock;
    private readonly Jester _jesterInstance;

    public JesterTests()
    {
        JokeServiceMock = new Mock<IJokeService>();
        JokeOutputMock = new Mock<IJokeOutput>();
        _jesterInstance = new Jester(JokeServiceMock.Object, JokeOutputMock.Object);
    }


    [Fact]
    public void Constructor_NullJokeService_ThrowsArgumentNullException()
    {
        IJokeService? jokeService = null;  // Use nullable reference type annotation
        IJokeOutput jokeOutput = Mock.Of<IJokeOutput>();

        Assert.Throws<ArgumentNullException>(() => new Jester(jokeService!, jokeOutput));  // Use the null-forgiving operator (!)
    }

    [Fact]
    public void Constructor_NullJokeOutput_ThrowsArgumentNullException()
    {
        IJokeService jokeService = Mock.Of<IJokeService>();
        IJokeOutput? jokeOutput = null;  // Use nullable reference type annotation

        Assert.Throws<ArgumentNullException>(() => new Jester(jokeService, jokeOutput!));  // Use the null-forgiving operator (!)
    }

    [Fact]
    public void TellJoke_ChuckNorrisJoke_Skips()
    {
        string chuckJoke = "Chuck Norris";
        string joke = "joke";
        int count = 0;

        JokeServiceMock?.Setup(js => js.GetJoke()).Returns(() => count++ == 0 ? chuckJoke : joke);

        _jesterInstance.TellJoke();

        // Verify that the method was called with the non-Chuck Norris joke
        JokeOutputMock?.Verify(co => co.PrintingJoke(joke), Times.Once);
    }
    

}

