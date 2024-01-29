using Moq;
using Xunit;

namespace CanHazFunny.Tests;

    public class JokeServiceTests
    {

        [Fact]
        public void GetJoke_ValidJoke_SuccessfulReturn()
        {
            // Arrange
            JokeService service = new();


            // Act
            string joke = service.GetJoke();

            // Arrange
            Assert.NotNull(joke);
        }

    }

