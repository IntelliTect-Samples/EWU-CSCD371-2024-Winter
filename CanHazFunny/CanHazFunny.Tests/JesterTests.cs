using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_Not_Norris()
    {
        string joke = Jester.TellJoke();
        Assert.DoesNotContain("Chuck Norris".ToLower(), joke.ToLower());
    }
    [Fact]
    public void TellJoke_CheckNotNull()
    {
        string joke = Jester.TellJoke();
        Assert.NotNull(joke);
    }


}
