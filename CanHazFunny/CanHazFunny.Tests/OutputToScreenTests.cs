using System;
using System.Globalization;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

    public class OutputToScreenTests
    {
        [Theory]
        [InlineData("How do robots eat pizza? One byte at a time.")]
        [InlineData("Why was the computer cold? It left its Windows open!")]

        public void WriteJokeToScreen_ValidJoke_PrintsCorrectly(string joke)
        {

            // Arrange
            OutputToScreen jokeWriter = new();
            using StringWriter streamWriter = new(CultureInfo.InvariantCulture);
            Console.SetOut(streamWriter);

            // Act
            jokeWriter.WriteJokeToScreen(joke);
            string consoelOutput = streamWriter!.ToString();

            // Assert
            Assert.Equal(joke + Environment.NewLine, consoelOutput);
        }

    }
