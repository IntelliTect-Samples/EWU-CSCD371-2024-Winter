using Xunit;

namespace CanHazFunny;


public class JokeServiceTests
{
    [Fact]
    public void GetJoke_CreatesJoke_ReturnsNonNullJoke()
    {
        // Act
        JokeService jokeService = new();
        
        // Arrange
        string getJoke = jokeService.GetJoke();
    
        // Assert 
        Assert.NotNull(getJoke);
    }

}