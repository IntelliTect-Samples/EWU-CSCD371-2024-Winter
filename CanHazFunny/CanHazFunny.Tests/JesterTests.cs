using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void TellJoke_Should_Write_To_Output()
        {
            var mockOutputWriter = new Mock <IOutputWriter>();
            var mockJokeService = new Mock <IJokeService>();

            mockJokeService.Setup(s => s.GetJoke()).Returns("Funny Joke");

            //Instance of Jester with MD
            var jester = new Jester(mockOutputWriter.Object, mockJokeService.Object);

            //Act
            jester.TellJoke();

            //Assert
            mockOutputWriter.Verify(o => o.Write(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void TellJoke_Skip_Chuck_Norris_Jokes()
        {
            //Arrange 
            var mockOutputWriter = new Mock <IOutputWriter>();
            var mockJokeService = new Mock <IJokeService>();

            mockJokeService.SetupSequence(s => s.GetJoke())
                .Returns("Chuck Norris Joke")
                .Returns("Funny Joke");

            var jester = new Jester(mockOutputWriter.Object, mockJokeService.Object);

            //Act
            jester.TellJoke();

            //Assert 
            mockOutputWriter.Verify(o => o.Write(It.IsAny<string>()), Times.Once);
        }
    }
}