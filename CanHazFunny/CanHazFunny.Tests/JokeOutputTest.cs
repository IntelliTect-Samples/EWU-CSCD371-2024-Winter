using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JokeOutputTest
{
    [Fact]
    public void WriteJoke_Throws_Exception_When_Joke_Is_Null()
    {
        // Arrange
        JokeOutput jokeOutput = new JokeOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => jokeOutput.WriteJoke(null!));
    }

}



