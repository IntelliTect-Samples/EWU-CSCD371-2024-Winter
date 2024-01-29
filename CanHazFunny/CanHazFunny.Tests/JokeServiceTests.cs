using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_RetrievesJoke_ReturnsSucessful()
    {
        JokeService jokeService = new();
        string joke = jokeService.GetJoke();
        Assert.NotNull(joke);
    }
}
