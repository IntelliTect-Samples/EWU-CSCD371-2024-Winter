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

        [Fact]
        public void ParseJokeJSON_ParseJSon_ReturnsJokeAsString()
        {
            string jokeJSON = "{{\"joke\": \"Jesus can walk on water, but Chuck Norris can walk on Jesus.\"}}";
            string expectedParsedString = "Jesus can walk on water, but Chuck Norris can walk on Jesus.";

            string actualParsedString = JokeService.ParseJokeJSON(jokeJSON);

            // Mark said this was okay to use generic equals method for strings
            #pragma warning disable xUnit2006 // Do not use invalid string equality check
            Assert.Equal<string>(expectedParsedString, actualParsedString);
            #pragma warning restore xUnit2006 // Do not use invalid string equality check

    }

}

