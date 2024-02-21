using Calculate;

namespace CalculateTests.Tests;

    public class ProgramTests
    {

    //XUnit tests - Assert.Equal are generic by default
       [Fact]
        public void WriteLine_InvokesWriteLine_Success()
        {
            // Arrange
            var expectedOutput = "Test Output";
            string? actualOutput = null;
            var program = new Program
            {
                // Set custom WriteLine delegate
                WriteLine = (text) => actualOutput = text
            };

            // Act
            program.WriteLine(expectedOutput);

            // Assert
            Assert.Equal(expectedOutput, actualOutput); // Verify WriteLine behavior
        }

        [Fact]
        public void ReadLine_InvokesReadLine_Success()
        {
            // Arrange
            var expectedInput = "Test Input";
            var program = new Program
            {
                // Set custom ReadLine delegate
                ReadLine = () => expectedInput
            };

            // Act
            var userInput = program.ReadLine();

            // Assert
            Assert.Equal(expectedInput, userInput); // Verify ReadLine behavior
        } 

    }

