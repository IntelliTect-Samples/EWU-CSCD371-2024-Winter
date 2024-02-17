namespace Calculate.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(2,1,1)]
    [InlineData(-2, -5, 3)]
    [InlineData(100, 99, 1)]
    [InlineData(25, 14, 11)]
    public void Add_ReturnCorrectResult_True(double expected, int value1, int value2)
    {
        double result = Calculator.Add(value1, value2);
        Assert.Equal(expected, result);
    }
}