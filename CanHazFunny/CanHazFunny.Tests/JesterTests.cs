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
        public void Constructor_NullDependencies_ThrowsNullException()
        {
            IJokeService? jokeDependencyMock = null;
            IOutputToScreen? outputDependencyMock = null;
            Jester? jester = new Jester(jokeDependencyMock!, outputDependencyMock!);
            // string result = jester.GetJoke();
        }
        [TestMethod]
        public void TellJoke_ValidJoke_WritesOutputCorrectly()
        {
            // ARRANGE
            Mock<IJokeService> jokeServiceMock = new Mock<IJokeService>();
            Mock<IOutputToScreen> outputDependencyMock = new Mock<IOutputToScreen>();

            // Set up the mock to return a joke
            jokeServiceMock.Setup(j => j.GetJoke()).Returns(() => new Jester(jokeServiceMock.Object, outputDependencyMock.Object).GetJoke());
            Jester jester = new Jester(jokeServiceMock.Object, outputDependencyMock.Object);


            // Act
            jester.TellJoke();

            // Assert
            outputDependencyMock.Verify(o => o.WriteJokeToScreen(It.IsAny<string>()), Times.Once);
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
