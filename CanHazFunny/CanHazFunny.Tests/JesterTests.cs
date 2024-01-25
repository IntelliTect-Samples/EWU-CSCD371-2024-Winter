using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Constructor_ValidInput_InitializesCorrectly()
        {
            // Arrange
            Mock<IJoke> jokeDependencyMock = new Mock<IJoke>();
            Mock<IOutputToScreen> outputDependencyMock = new Mock<IOutputToScreen>();

            // Act
            Jester jester = new Jester(jokeDependencyMock.Object, outputDependencyMock.Object);

            // Assert
            Assert.IsNotNull(jester);
            Assert.AreSame(jokeDependencyMock.Object, jester.GetJokeDependency());
            Assert.AreSame(outputDependencyMock.Object, jester.GetOutputDependency());
        }


        [TestMethod]
        public void TellJoke_ValidJokeInput_WritesOutputCorrectly()
        {
            // Arrange
            Mock<IJoke> jokeDependencyMock = new Mock<IJoke>();
            Mock<IOutputToScreen> outputDependencyMock = new Mock<IOutputToScreen>();

            // Act
            Jester jester = new Jester(jokeDependencyMock.Object, outputDependencyMock.Object);

            // Assert
            Assert.IsNotNull(jester);
            Assert.AreSame(jokeDependencyMock.Object, jester.GetJokeDependency());
            Assert.AreSame(outputDependencyMock.Object, jester.GetOutputDependency());
        }

        [TestMethod]
        public void TellJoke_ChuckNorrisJoke_SuccessfulSkip()
        {
            // Arrange
            Mock<IJoke> jokeDependencyMock = new Mock<IJoke>();
            Mock<IOutputToScreen> outputDependencyMock = new Mock<IOutputToScreen>();

            // Set up the mock to return a Chuck Norris joke
            jokeDependencyMock.Setup(j => j.GetJoke()).Returns("Chuck Norris joke");

            Jester jester = new Jester(jokeDependencyMock.Object, outputDependencyMock.Object);

            // Act
            jester.TellJoke();

            // Assert
            // Ensure WriteToScreen is not called when the joke contains "Chuck Norris"
            outputDependencyMock.Verify(o => o.WriteJokeToScreen(It.IsAny<string>()), Times.Never);
        }
    }
    


    
}
