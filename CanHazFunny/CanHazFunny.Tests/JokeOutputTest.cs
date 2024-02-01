using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JokeOutputTest
{
    [Fact]
    public void WriteJokeThrowsExceptionWhenJokeIsNull()
    {
        // Arrange
        JokeOutput jokeOutput = new JokeOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => jokeOutput.WriteJoke(null!));
    }

}



