using Moq;
using System;
using Xunit;

namespace CanHazFunny.Tests;

    public class JesterTests
    {
        [Fact]
        public void Constructor_NullJokeService_ThrowsNullException()
        {
        //Assert should throw exception
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new OutputToScreen()));

        }

        [Fact]
        public void Constructor_NullOutputToScreen_ThrowsNullException()
        {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new OutputToScreen()));
        }

        [Theory]
        [InlineData("What do you call a computer that sings? A Dell!")]    
        [InlineData("Why do programmers prefer dark mode? Because light attracts bugs!")]    
        public void TellJoke_ValidJoke_WritesOutputCorrectly(string joke)
        {
            // Arrange
            Mock<IJokeService> jokeServiceMock = new();
            Mock<IOutputToScreen> outputMock = new();
            // Set up mock to return a joke
            jokeServiceMock.SetupSequence(JokeService => JokeService.GetJoke()).Returns(joke);
            outputMock.SetupSequence(OutputToScreen => OutputToScreen.WriteJokeToScreen(joke));
            Jester jester = new(jokeServiceMock.Object, outputMock.Object);


            // Act
            jester.TellJoke();

            // Assert
            outputMock.VerifyAll();
        }

        [Fact]
        public void TellJoke_ChuckNorrisJoke_SuccessfulSkip()
        {
             // Arrange
            Mock<IJokeService> jokeMock = new();
            Mock<IOutputToScreen> outputMock = new();
            string chuckJoke = "When God said, �Let there be light!� Chuck Norris said, �Say Please.";
            string noChuckJoke = "Why did the programmer break up with his girlfriend? She just didn�t meet his conditional statements.";
            jokeMock.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns(chuckJoke)
                .Returns(noChuckJoke);
            outputMock.SetupSequence(OutputToScreen => OutputToScreen.WriteJokeToScreen(noChuckJoke));
            Jester jester = new(jokeMock.Object, outputMock.Object);

            // Act
            jester.TellJoke();

            // Assert
            jokeMock.Verify(jokeMock => jokeMock.GetJoke(), Times.Exactly(2));
            outputMock.Verify(OutputToScreen => OutputToScreen.WriteJokeToScreen(noChuckJoke), Times.Once());
        }

    }
    
