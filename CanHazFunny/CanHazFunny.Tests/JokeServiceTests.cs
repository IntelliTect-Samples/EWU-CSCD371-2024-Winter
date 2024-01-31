using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_CallWebsite_ReturnJoke()
    {
        JokeService jokeService = new();
        string result = jokeService.GetJoke();
        Assert.NotNull(result);
    }
}