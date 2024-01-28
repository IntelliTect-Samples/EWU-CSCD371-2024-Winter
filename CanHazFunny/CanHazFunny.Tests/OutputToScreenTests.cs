using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CanHazFunny.Tests;

    [TestClass]
    public class OutputToScreenTests
    {
        [TestMethod]
        [DataRow("How do robots eat pizza? One byte at a time.")]
        [DataRow("Why was the computer cold? It left its Windows open!")]

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
            Assert.AreEqual<string>(joke + Environment.NewLine, consoelOutput);
        }

    }
