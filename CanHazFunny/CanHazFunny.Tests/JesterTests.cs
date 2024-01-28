using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;

namespace CanHazFunny.Tests;

    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullJokeService_ThrowsNullException()
        {
            //Assert should throw exception
            new Jester(null!, new OutputToScreen());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullOutputToScreen_ThrowsNullException()
        {
            new Jester(new JokeService(), null!);
        }

        [TestMethod]
        [DataRow("What do you call a computer that sings? A Dell!")]    
        [DataRow("Why do programmers prefer dark mode? Because light attracts bugs!")]    
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

        [TestMethod]
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
    
