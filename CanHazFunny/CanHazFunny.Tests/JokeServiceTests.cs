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
            //  Mock<HttpClient> httpClientMock = new Mock<HttpClient>();
            Mock<IJokeService> jokeServiceMock = new Mock<IJokeService>();

            JokeService jokeService = new JokeService(jokeServiceMock.Object);

            string expResult = jokeService.GetJoke();
            string result = jokeService.GetJoke();
            Assert.Equals(expResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetJoke_NullJoke_ThrowsNullException()
        {
            IJokeService? jokeService = null;
            JokeService? instance = new JokeService(jokeService!);

            // Act
            string result = instance.GetJoke();
        }
    }



}

