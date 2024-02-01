using Xunit;
using Moq;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_ReturnsJoke_NotNullOrEmpty()
    {
        var jokeService = new JokeService();

        string result = jokeService.GetJoke();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
