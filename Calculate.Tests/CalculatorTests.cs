using Xunit;
using Xunit.Sdk;

namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Multilple_Success()
    {
        Assert.Equal<int>(12, Calculator.Multiple(3,4));
    }

    [Fact]
    public void Divide_Success()
    {
        Assert.Equal<double>(2.0, Calculator.Divide(8,4));
    }
}