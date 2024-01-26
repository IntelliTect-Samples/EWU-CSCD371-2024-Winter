using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

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

        }
    }
}
