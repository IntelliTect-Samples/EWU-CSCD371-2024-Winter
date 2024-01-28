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
            //Act
            Mock<IJokeService> service = new();
            string joke = "Hahahahah";

            service.SetupSequence(service => service.GetJoke()).Returns(joke);

            JokeService jokeService = new ();
            //Assert joke is not null 
            Assert.AreEqual(joke, service.Object.GetJoke());
        }

        //[TestMethod]
     /*   [ExpectedException(typeof(ArgumentNullException))]
        public void GetJoke_NullJoke_ThrowsNullException()
        {
            IJokeService? jokeService = null;
            JokeService? instance = new JokeService(jokeService!);

            // Act
            string result = instance.GetJoke();
        }
     */
    }
}

