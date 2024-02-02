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

        [Theory]
        [InlineData("Jesus can walk on water, but Chuck Norris can walk on Jesus.", "{{\"joke\": \"Jesus can walk on water, but Chuck Norris can walk on Jesus.\"}}")]
        [InlineData("When Chuck Norris says 'More cowbell', he MEANS it.", "{{\"joke\": \"When Chuck Norris says 'More cowbell', he MEANS it.\"}}")]
        [InlineData("In the movie 'The Matrix', Chuck Norris is the Matrix. If you pay close attention in the green 'falling code' scenes, you can make out the faint texture of his beard.", "{{\"joke\": \"In the movie 'The Matrix', Chuck Norris is the Matrix. If you pay close attention in the green 'falling code' scenes, you can make out the faint texture of his beard.\"}}")]
        public void ParseJokeJSON_ParseJSon_ReturnsJokeAsString(string expectedParsedString , string jokeJSON)
        {


            string actualParsedString = JokeService.ParseJokeJSON(jokeJSON);

            // Mark said this was okay to use generic equals method for strings
            #pragma warning disable xUnit2006 // Do not use invalid string equality check
            Assert.Equal<string>(expectedParsedString, actualParsedString);
            #pragma warning restore xUnit2006 // Do not use invalid string equality check

    }

}

