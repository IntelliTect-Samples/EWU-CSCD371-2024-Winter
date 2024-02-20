
using Xunit;

namespace Calculate.Tests;

    public class CalculateTests
    {

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

        [Fact]
        public void TryCalcuate_ValidAddition_ReturnsTrue()
        {
            Assert.True(Calculator.TryCalculate("3 + 3"));
        }

}
