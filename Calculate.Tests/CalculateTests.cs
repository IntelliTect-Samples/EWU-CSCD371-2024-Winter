
using Xunit;

namespace Calculate.Tests;

    public class CalculateTests
    {

        [Fact]
        public void Add_ValidNumber_ReturnsAdditionResult()
        {
            Assert.Equal(3, Calculator.Add(3, 3));
        }
    
}
