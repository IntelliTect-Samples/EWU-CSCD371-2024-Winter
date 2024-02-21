using Xunit;
using System.IO;
using System.ComponentModel;

namespace Calculate.Tests;

    public class ProgramTests : IDisposable
    {

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static string TempPath { get; set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
       
        public ProgramTests()
        {
            TempPath = Path.GetTempFileName();
        }

        static void WriteLinetoStream(string value)
        {
            using StreamWriter streamReader = new(TempPath);
            streamReader.WriteLine(value);
        }
        static string? ReadLineFromFile()
        {
            using StreamReader streamReader = new(TempPath);
            return streamReader.ReadLine();
        }


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

        [Fact]
        public void Constructor_InitFileWriteLine_ExpectedBehavior()
        {
            Program program = new()
            {
                WriteLine = WriteLinetoStream
            };

            program.WriteLine("Hello World");

            using StreamReader streamReader = new(TempPath);
            Assert.Equal("Hello World",streamReader.ReadLine());

        }

    public void Dispose()
    {
        if (File.Exists(TempPath))
        {
            File.Delete(TempPath);
            GC.SuppressFinalize(this);
        }
    }
}


