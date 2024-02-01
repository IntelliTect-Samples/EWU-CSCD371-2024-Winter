using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JokeOutputTest
{
    [Fact]
    public void WriteJoke_WhenJokeIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        JokeOutput jokeOutput = new JokeOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => jokeOutput.WriteJoke(null!));
    }

}



