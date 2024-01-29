using Moq;
using Xunit;

namespace CanHazFunny.Tests;

    public class JokeServiceTests
    {

        [Fact]
        public void GetJoke_ValidJoke_SuccessfulReturn()
        {
            // Arrange
            Mock<IJokeService> service = new();
            string expectedJoke = "Hahahahah";
            service.SetupSequence(service => service.GetJoke()).Returns(expectedJoke);

            // Act
            string actualJoke = service.Object.GetJoke();

            // Arrange
            Assert.Equal(expectedJoke, actualJoke);
        }

    }

