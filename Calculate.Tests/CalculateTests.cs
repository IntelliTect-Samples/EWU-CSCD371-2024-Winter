using Xunit;

namespace Calculate.Tests;

    public class CalculateTests
    {
        public Calculator<double> Calculator { get;}

        public CalculateTests() 
        {
            Calculator = new Calculator<double>();
        }

        [Fact]
        public void Add_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(6, Calculator.MathematicalOperations['+'](3.0, 3));
        }
        [Fact]
        public void Subtract_ValidNumbers_ReturnsExpectedResult()
        {
            Calculator<float> floatCalculator = new();
            Assert.Equal(6.4 - 3.7, Calculator.MathematicalOperations['-'](6.4, 3.7));
        }
        [Fact]
        public void Multiply_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(9, Calculator.MathematicalOperations['*'](3, 3));
        }
        [Fact]
        public void Divide_ValidNumbers_ReturnsExpectedResult()
        {
            Assert.Equal(1, Calculator.MathematicalOperations['/'](3, 3));
        }
        [Fact]
        public void Divide_ZeroDenominator_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.MathematicalOperations['/'](3, 0));
        }

        [Theory]
        [InlineData(6, "3 + 3")]
        [InlineData(0, "3 - 3")]
        [InlineData(135, "45 * 3")]
        [InlineData(16, "64 / 4")]
        public void TryCalcuate_ValidExpression_CalculatesCorrectly(double expected, string expression)
        {
            Calculator.TryCalculate(expression, out double res);
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
