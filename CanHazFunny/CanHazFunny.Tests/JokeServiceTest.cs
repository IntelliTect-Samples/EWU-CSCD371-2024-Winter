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

    [Theory]
    [InlineData("Where do computer programmers go for fun? The disc-o!")]
    [InlineData("What's a computer scientist's favourite type of coffee? Java.")]
    public void WriteJokeToScreen_ValidJoke_PrintsCorrectly(string joke)
    {
        // Arrange
        JokeOutput JokeWriter = new();
        using StringWriter streamWriter = new(CultureInfo.InvariantCulture);
        Console.SetOut(streamWriter);

        // Act
        JokeWriter.WriteJoke(joke);
        string consoleOutput = streamWriter.ToString();

        // Assert
        Assert.Equal(joke + Environment.NewLine, consoleOutput);
    }

}



