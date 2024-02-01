using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


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
    public void TellJoke_WhenChuckNorrisJokeEncountered_SkipsChuckNorrisJoke()
    {
        // Arrange
        var mockService = new Mock<IService>();
        var mockOutput = new Mock<IOutput>();

        mockService.SetupSequence(x => x.GetJoke())
                       .Returns("Chuck norris joke") // checking joke w/different capitalization
                       .Returns("LMAO");

        var jester = new Jester(mockService.Object, mockOutput.Object);
        
        //Act
        jester.TellJoke();


        // Assert
        mockService.Verify(x => x.GetJoke(), Times.Exactly(2));
        mockOutput.Verify(x => x.WriteJoke("LMAO"), Times.Once);

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


}



