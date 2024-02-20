using Xunit;

namespace Calculate.Tests;

    public class ProgramTests
    {
        [Fact]
        public void DefaultConstructor_WriteLineProperty_ExpectedBehaviour()
        {
            Program program = new();
            using StringWriter mockConsole = new();

            Console.SetOut(mockConsole);

            program.WriteLine("Hello");

            Assert.Contains("Hello", mockConsole.ToString());

        }
    [Fact]
        public void DefaultConstructor_ReadLineProperty_ExpectedBehaviour()
        {
            Program program = new();
            

            Console.SetIn(new StringReader("Hello"));

            Assert.Equal("Hello", program.ReadLine());

        }
}
