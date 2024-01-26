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
        public void TellJoke_ValidJoke2_WritesOutputCorrectly2()
        {
            // Arrange
            string joke = "Why do programmers prefer dark mode? Because light attracts bugs!";
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
             // Arrange
             Mock<IJokeService> jokeMock = new Mock<IJokeService>();
            //Mock<IOutputToScreen> outputMock = new Mock<IOutputToScreen>();

            // Set up mock to return a Chuck Norris joke
            jokeMock.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("When God said, “Let there be light!” Chuck Norris said, “Say Please.")
              //  .Returns("Chuck Norris knows Victoria's Secret.")
                .Returns("Why did the programmer break up with his girlfriend? She just didn’t meet his conditional statements.");

            Jester jester = new Jester(jokeMock.Object, new OutputToScreen());
             // Act
             jester.TellJoke();
            
            // Ensure joke is skipped
            jokeMock.Verify(jokeMock => jokeMock.GetJoke(), Times.Once());
            // outputMock.Verify(o => o.WriteJokeToScreen(It.IsAny<string>()), Times.Never or Times.Exactly);
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
