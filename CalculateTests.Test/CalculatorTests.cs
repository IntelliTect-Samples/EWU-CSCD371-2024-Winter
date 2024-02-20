using Xunit;
using Calculate;

namespace CalculateTests.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd()
        {
            // Arrange
            int x = 5;
            int y = 3;

            // Act
            int result = Calculator.Add(x, y);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void TestSubtract()
        {
            // Arrange
            int x = 5;
            int y = 3;

            // Act
            int result = Calculator.Subtract(x, y);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestMultiply()
        {
            // Arrange
            int x = 5;
            int y = 3;

            // Act
            int result = Calculator.Multiply(x, y);

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void TestDivide()
        {
            // Arrange
            int x = 6;
            int y = 3;

            // Act
            int result = Calculator.Divide(x, y);

            // Assert
            Assert.Equal(2, result);
        }
    }
}
