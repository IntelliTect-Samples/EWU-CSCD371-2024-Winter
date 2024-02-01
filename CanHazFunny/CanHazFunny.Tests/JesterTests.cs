using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JesterTests
{
    [Fact]
    public void IServicePropertySetNullSuccessfully()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeOutput()));

    }

    [Fact]
    public void IOutputPropertySetNullSuccessfully()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));

    }

    [Fact]
    public void TellJokeChuckNorrisJokeSkipsSuccessfully()
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

}



