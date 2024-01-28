using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;

    [TestClass]
    public class JokeServiceTests
    {

        [TestMethod]
        public void GetJoke_ValidJoke_SuccessfulReturn()
        {
            // Arrange
            Mock<IJokeService> service = new();
            string expectedJoke = "Hahahahah";
            service.SetupSequence(service => service.GetJoke()).Returns(expectedJoke);

            // Act
            string actualJoke = service.Object.GetJoke();

            // Arrange
            Assert.AreEqual<string>(expectedJoke, actualJoke);
        }

    }

