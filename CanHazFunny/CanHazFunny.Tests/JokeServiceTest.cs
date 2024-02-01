using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;
#pragma warning disable CA1707


public class JokeServiceTest
{

    [Fact]
    public void GetJoke_JokeisValid_ReturnsSuccess()
    {
        // Arrange
        JokeService service = new JokeService();

        // Act
        string joke = service.GetJoke();

        // Arrange
        Assert.NotNull(joke);
    }

}



