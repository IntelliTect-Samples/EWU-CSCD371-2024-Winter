using Xunit;

namespace Calculate.Tests;

    public class ProgramTests
    {
        [Fact]
        public void Constructor_WriteLineProperty_ExpectedBehaviour()
        {
            Program program = new();
            using StringWriter mockConsole = new();

            Console.SetOut(mockConsole);

            program.WriteLine("Hello");

            Assert.Contains("Hello", mockConsole.ToString());

        }
    }
