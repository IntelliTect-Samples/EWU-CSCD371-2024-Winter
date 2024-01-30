using Xunit;

namespace CanHazFunny;


public class JokeServiceTests
{
    [Fact]
    public void GetJoke_CreatesJoke_ReturnsNonNullJoke()
    {
        // Arrange
        JokeService jokeService = new();
        
        // Act
        string getJoke = jokeService.GetJoke();
    
        // Assert 
        Assert.NotNull(getJoke);
    }

}