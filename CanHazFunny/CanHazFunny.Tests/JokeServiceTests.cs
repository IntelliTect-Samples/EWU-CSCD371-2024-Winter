using Xunit;

namespace CanHazFunny.Tests;
public class JokeServiceTests
{
    [Fact]
    public void GetJoke_ReciveString_Success()
    {
        JokeService service = new();
        Assert.IsType<string>(service.GetJoke());
    }
}
