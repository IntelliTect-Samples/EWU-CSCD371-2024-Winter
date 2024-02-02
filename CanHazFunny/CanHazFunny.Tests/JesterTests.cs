using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;
#pragma warning disable CA1707


public class JesterTests
{
    [Fact]
    public void IService_SetNull_ThrowsArgumentNullException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeOutput()));

    }

    [Fact]
    public void IOutput_SetNull_ThrowsArgumentNullException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));

    }

    [Fact]
    public void TellJoke_ChuckNorrisJoke_SuccessfulSkip()
    {
        // Arrange
        Mock<IService> JokeMock = new();
        Mock<IOutput> OutputMock = new();
        string JokeChuck = "Chuck Norris doesn't need garbage collection because he doesn't call .Dispose(), he calls .DropKick().";
        string JokeProgrammer = "Why don't programmers like nature? It has too many bugs.";

        JokeMock.SetupSequence(jokeService => jokeService.GetJoke())
            .Returns(JokeChuck)
            .Returns(JokeProgrammer);

        OutputMock.Setup(OutputToScreen => OutputToScreen.WriteJoke(It.IsAny<string>()));

        Jester jester = new(JokeMock.Object, OutputMock.Object);

        // Act
        jester.TellJoke();

        // Assert
        JokeMock.Verify(jokeMock => jokeMock.GetJoke(), Times.Exactly(2));
        OutputMock.Verify(OutputToScreen => OutputToScreen.WriteJoke(It.IsAny<string>()), Times.Once());
    }


    [Fact]
    public void TellJoke_DisplayCorrectJoke_Success()
    {
        // Arrange
        string joke = "It was such a good joke";
        var mockJokeService = new Mock<IService>();
        mockJokeService.Setup(x => x.GetJoke()).Returns(joke);
        var mockOutService = new Mock<IOutput>();
        Jester jester = new(mockJokeService.Object, mockOutService.Object);

        // Act
        jester.TellJoke();

        // Assert
        mockOutService.Verify(x => x.WriteJoke(joke));

    }

    [Fact]
    public void TellJoke_MultipleValidJokes_ReturnsDifferentJokes()
    {
        // Arrange
        var jokes = new string[] { "Joke 1", "Joke 2", "Joke 3" };
        var mockService = new Mock<IService>();
        var mockOutput = new Mock<IOutput>();
        mockService.SetupSequence(x => x.GetJoke())
                       .Returns(jokes[0])
                       .Returns(jokes[1])
                       .Returns(jokes[2]);
        var jester = new Jester(mockService.Object, mockOutput.Object);

        // Act
        jester.TellJoke();
        jester.TellJoke();
        jester.TellJoke();

        // Assert
        mockOutput.Verify(x => x.WriteJoke(It.IsAny<string>()), Times.Exactly(3));
    }

    [Theory]
    [InlineData("CS Joke Here? :3!")]
    [InlineData("Joke 2? Tehe!")]
    public void TellJoke_JokeisValid_WriteOutputSuccess(string joke)
    {
        // Arrange
        Mock<IService> ServiceMock = new();
        Mock<IOutput> OutputMock = new();
        ServiceMock.SetupSequence(JokeService => JokeService.GetJoke()).Returns(joke);
        OutputMock.SetupSequence(OutputToScreen => OutputToScreen.WriteJoke(joke));
        Jester jester = new(ServiceMock.Object, OutputMock.Object);

        // Act
        jester.TellJoke();

        // Assert
        OutputMock.VerifyAll();

    }

}



