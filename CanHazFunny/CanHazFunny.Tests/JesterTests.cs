using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullJokeService_ThrowsNullException()
        {
            //Assert should throw exception
            Jester? jester = new Jester(null!, new OutputToScreen());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullOutputToScreen_ThrowsNullException()
        {
            Jester? jester = new Jester(new JokeService(), null!);
        }
        [TestMethod]
        public void TellJoke_ValidJoke_WritesOutputCorrectly()
        {
            // Arrange
            string joke = "What do you call a computer that sings? A Dell!";
            Mock<IJokeService> jokeServiceMock = new Mock<IJokeService>();
            Mock<IOutputToScreen> outputMock = new Mock<IOutputToScreen>();
            // Set up mock to return a joke
            jokeServiceMock.SetupSequence(JokeService => JokeService.GetJoke()).Returns(joke);
            outputMock.SetupSequence(OutputToScreen => OutputToScreen.WriteJokeToScreen(joke));
            Jester jester = new Jester(jokeServiceMock.Object, outputMock.Object);


            // Act
            jester.TellJoke();

            // Assert
            outputMock.VerifyAll();
          }
        [TestMethod]
        public void TellJoke_ChuckNorrisJoke_SuccessfulSkip()
        {
            /* // Arrange
             Mock<IJoke> jokeDependencyMock = new Mock<IJoke>();
             Mock<IOutputToScreen> outputDependencyMock = new Mock<IOutputToScreen>();

             // Set up mock to return a Chuck Norris joke
             jokeDependencyMock.Setup(j => j.GetJoke()).Returns("Chuck Norris joke");

             Jester jester = new Jester(jokeDependencyMock.Object, outputDependencyMock.Object);

             // Act
             jester.TellJoke();

            
            // Ensure TellJoke is called again when the first joke contains "Chuck Norris"
            jokeServiceMock.Verify(j => j.GetJoke(), Times.Exactly(2));
             outputDependencyMock.Verify(o => o.WriteJokeToScreen(It.IsAny<string>()), Times.Never);
         }

        /* [Test]
         public void Ping_invokes_DoSomething()
         {
             // ARRANGE
             var mock = new Mock<IJoke>();
             mock.Setup(p => p.methodhere(It.IsAny<string>())).Returns(true);
             var sut = new Jester(mock.Object);

             // ACT
             sut.Ping();

             // ASSERT
             mock.Verify(p => p.methodhere("PING"), Times.Once());
         }
        */
        }
    }
}
