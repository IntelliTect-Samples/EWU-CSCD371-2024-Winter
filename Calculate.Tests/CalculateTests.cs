
using System.Linq.Expressions;
using Xunit;

namespace Calculate.Tests;

    public class CalculateTests
    {
        public Calculator Calculator { get;}

        public CalculateTests() 
        {
            Calculator = new Calculator();
        }

        [Fact]
        public void Add_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(6, Calculator.Add(3, 3));
        }
        [Fact]
        public void Subtract_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(3, Calculator.Subtract(6, 3));
        }
        [Fact]
        public void Multiply_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(9, Calculator.Multiply(3, 3));
        }
        [Fact]
        public void Divide_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(1, Calculator.Divide(3, 3));
        }

        [Theory]
        [InlineData(6, "3 + 3")]
        [InlineData(0, "3 - 3")]
        [InlineData(135, "45 * 3")]
        [InlineData(16, "64 / 4")]
        public void TryCalcuate_ValidExpression_CalculatesCorrectly(int expected, string expression)
        {
            Calculator.TryCalculate(expression, out int res);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("One + 2")]
        [InlineData("1 + Two")]
        [InlineData("Oon - Two")]
        public void TryCalculate_InvalidOperands_ReturnsFalse(string expression)
        {
            Assert.False(Calculator.TryCalculate(expression, out _));
        }

        [Theory]
        [InlineData("1+ 2")]
        [InlineData("1 +2")]
        [InlineData("1  -  2")]
        [InlineData("1-2")]
        public void TryCalculate_UnformattedWhiteSpace_ReturnsFalse(string expression)
        {
            Assert.False(Calculator.TryCalculate(expression, out _));
        }

        [Theory]
        [InlineData("1 # 2")]
        [InlineData("1 ^ 2")]
        [InlineData("1 ** 2")]
        [InlineData("1 @ 2")]
        public void TryCalculate_InvalidOperator_ReturnsFalse(string expression)
        {
            Assert.False(Calculator.TryCalculate(expression, out _));
        }

}
