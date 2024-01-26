using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class OutputToScreenTests
    {
        [TestMethod]
        public void WriteJokeToScreen_ValidJoke_PrintsCorrectly()
        {
            string joke = "How do robots eat pizza? One byte at a time.";
            OutputToScreen jokeWriter = new OutputToScreen();

            //Act and Arrange using StreamWriter
            using (StreamWriter streamWriter = new StreamWriter("output.txt")) 
            {
                Console.SetOut(streamWriter);
                jokeWriter.WriteJokeToScreen(joke);
            }
            string[] printerArr = File.ReadAllLines("output.txt");
            string printerString = string.Join("\n", printerArr);
            //Assert
            Assert.AreEqual(joke, printerString);
            //streamwriter puts Console.WriteLine to a file and the printerarr ensures 
            //all the joke will be captured if it has multiple lines
        }
        [TestMethod]
        public void WriteJokeToScreen2_ValidJoke_PrintsCorrectly2()
        {
            string joke = "Why was the computer cold? It left its Windows open!";
            OutputToScreen jokeWriter = new OutputToScreen();

            //Act and Arrange using StreamWriter
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                Console.SetOut(streamWriter);
                jokeWriter.WriteJokeToScreen(joke);
            }
            string[] printerArr = File.ReadAllLines("output.txt");
            string printerString = string.Join("\n", printerArr);
            //Assert
            Assert.AreEqual(joke, printerString);
            //streamwriter puts Console.WriteLine to a file and the printerarr ensures 
            //all the joke will be captured if it has multiple lines
        }
    }
}
