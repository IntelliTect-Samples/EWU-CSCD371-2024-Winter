using Xunit;
using Moq;
namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TESTPASS()
    {
        string test = "expected";
        Assert.Equal("expected", test);
    }
}
