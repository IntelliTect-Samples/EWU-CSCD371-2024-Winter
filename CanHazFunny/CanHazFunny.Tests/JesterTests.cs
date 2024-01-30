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


    [Fact]
    public void OutputJoke_WithoutChuckNorris_Successful()
    {
        // Arrange
        var moqJokeService = new Mock<IJokeService>();
        var moqJokeOutput = new Mock<IJokeOutput>();
        string testJoke = "test joke";
        moqJokeService.SetupSequence(x => x.GetJoke()).Returns(testJoke);
        Jester jesterTest = new Jester(moqJokeService.Object, moqJokeOutput.Object);
        
        // Act
        jesterTest.TellJoke();

        // Assert with moq
        moqJokeOutput.Verify(x => x.OutputJoke(testJoke));
    }


    [Fact]
    public void OuputJoke_WithChuckNorrisThenWithout_Successful()
    {
        // Arrange
        var moqJokeService = new Mock<IJokeService>();
        var moqJokeOutput = new Mock<IJokeOutput>();
        string chuckJoke = "Chuck Norris";
        string testJoke = "test joke";
        moqJokeService.SetupSequence(x => x.GetJoke()).Returns(chuckJoke).Returns(testJoke);
        Jester jesterTest = new Jester(moqJokeService.Object, moqJokeOutput.Object);

        // Act 
        jesterTest.TellJoke();

        // Assert with moq
        // Should skip chuckJoke and equal testJoke
        moqJokeOutput.Verify(x => x.OutputJoke(testJoke));
    }

}