using System;
using System.IO;
using Xunit;

namespace CanHazFunny;


public class JokeOutputTests
{
    [Fact]
    public void OutputJoke_PrintsGivenJoke_Succesfully()
    {
        // Arrange
        string testJoke = "test joke";
        JokeOutput jokeOutput = new(); 
        StringWriter outputJoke = new();  //Needs to be string writer since we need to take in System.IO.TextWriter 
        Console.SetOut(outputJoke);
        jokeOutput.OutputJoke(testJoke);


        // Act & Assert
        Assert.Equal(testJoke + "\n" , outputJoke.ToString());

    }
}