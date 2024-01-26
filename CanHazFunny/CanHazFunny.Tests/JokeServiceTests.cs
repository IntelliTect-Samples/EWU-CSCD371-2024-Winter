using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;



namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {

        [TestMethod]
        public void GetJoke_ValidJoke_SuccessfulReturn()
        {
            Mock<HttpClient> httpClientMock = new Mock<HttpClient>();
            JokeService instance = new JokeService(httpClientMock.Object);
            string expResult = "This is a joke";
            instance.SetJoke(expResult);
            string result = instance.GetJoke();
            Assert.Equals(expResult, result);
        }
        public void GetJoke_ReturnsChuckNorrisJoke()
        {
            // Arrange
            Mock<HttpClient> httpClientMock = new Mock<HttpClient>();
            httpClientMock.Setup(c => c.GetStringAsync(It.IsAny<string>()))
                .ReturnsAsync("Chuck Norris joke");

            JokeService jokeService = new JokeService(httpClientMock.Object);

            // Act
            string joke = jokeService.GetJoke();

            // Assert
            Assert.AreEqual("Chuck Norris joke", joke);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetJoke_NullJoke_ThrowsNullException()
        {
            JokeService instance = new JokeService(null);

            // Act
            string result = instance.GetJoke(); // This should throw an exception
        }

    }

}

