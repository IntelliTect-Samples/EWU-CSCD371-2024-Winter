using Xunit;
using Calculate;

namespace CalculateTests.Test;
    public class CalculatorTests
    {
        [Fact]
        public void Add_PositiveValues_ReturnsCorrect()
        {
            // Arrange
            double x = 5;
            double y = 3;

            // Act
            double result = Calculator.Add(x, y);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_PositiveValues_ReturnsCorrect()
        {
            // Arrange
            double x = 5;
            double y = 3;

            // Act
            double result = Calculator.Subtract(x, y);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Multiply_PositiveValues_ReturnsCorrect()
        {
            // Arrange
            double x = 5;
            double y = 3;

            // Act
            double result = Calculator.Multiply(x, y);

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void Divide_PositiveValues_ReturnsCorrect()
        {
            // Arrange
            double x = 6;
            double y = 3;

            // Act
            double result = Calculator.Divide(x, y);

            // Assert
            Assert.Equal(2, result);
        }


        [Theory]
        [InlineData("3 + 4", 7)] // Valid addition
        [InlineData("42 - 2", 40)] // Valid subtraction
        [InlineData("6 * 7", 42)] // Valid multiplication
        [InlineData("10 / 2", 5)] // Valid division
        public void TryCalculate_ValidExpression_ReturnsTrue(string expression, double expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            bool result = calculator.TryCalculate(expression, out double actual);

            // Assert
            Assert.True(result);
            Assert.Equal(expected, actual);
        }
    }
