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
            OutputToScreen jokeWriter = new();

            //Act and Arrange using StreamWriter
            using StringWriter streamWriter = new(CultureInfo.InvariantCulture);

            Console.SetOut(streamWriter);
            jokeWriter.WriteJokeToScreen(joke);

            string consoelOutput = streamWriter!.ToString();
            //Assert
            Assert.AreEqual(joke, consoelOutput);
            //streamwriter puts Console.WriteLine to a file and the printerarr ensures 
            //all the joke will be captured if it has multiple lines
        }

    }
