using Xunit;
using System;
using Moq;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_JokeOutputNull_ThrowsException()
    {
        // Arrange
        var moqJokeService = new Mock<IJokeService>();
        
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(moqJokeService.Object, null!));
    }

    [Fact]
    public void TellJoke_JokeServiceNull_ThrowsException()
    {
        // Arrange
        var moqJokeOutput = new Mock<IJokeOutput>();

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, moqJokeOutput.Object));
    }

}