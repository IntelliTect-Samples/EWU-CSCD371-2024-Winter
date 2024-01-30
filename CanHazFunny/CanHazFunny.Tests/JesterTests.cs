using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_Should_Write_Joke_To_Output()
        {
            // Arrange
            var mockOutputWriter = new Mock<IOutputWriter>();
            var mockJokeService = new Mock<IJokeService>();

            // Setup mock to return a joke without "Chuck Norris"
            mockJokeService.Setup(s => s.GetJoke()).Returns("Funny Joke");

            // Create an instance of Jester with mocked dependencies
            var jester = new Jester(mockOutputWriter.Object, mockJokeService.Object);

            // Act
            jester.TellJoke();

            // Assert using Assert.Equal<T>()
            Assert.Equal("Funny Joke", mockOutputWriter.Object.WriteSingleCallParameter());
        }

        [TestMethod]
        public void TellJoke_Should_Skip_Chuck_Norris_Jokes()
        {
            // Arrange
            var mockOutputWriter = new Mock<IOutputWriter>();
            var mockJokeService = new Mock<IJokeService>();

            // Setup mock to return a Chuck Norris joke
            mockJokeService.SetupSequence(s => s.GetJoke())
                .Returns("Chuck Norris Joke")
                .Returns("Funny Joke");

            // Create an instance of Jester with mocked dependencies
            var jester = new Jester(mockOutputWriter.Object, mockJokeService.Object);

            // Act
            jester.TellJoke();

            // Assert using Assert.Equal<T>()
            Assert.Equal("Funny Joke", mockOutputWriter.Object.WriteSingleCallParameter());
        }
    }
}
