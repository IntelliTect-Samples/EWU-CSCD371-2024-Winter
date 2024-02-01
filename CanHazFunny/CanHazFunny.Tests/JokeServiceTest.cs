using Xunit;
using Moq;
using System;
using System.Globalization;
using System.IO;

namespace CanHazFunny.Tests;
#pragma warning disable CA1707 // could not figure out my _ was giving me issues in the build 


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



