using Xunit;

namespace CanHazFunny.Tests;

public class IOutJokeTests
{
    [Fact]
    public void TestName()
    {
        MockClass mockClass = new();
    
        string joke = mockClass.TellJoke(); 
        Assert.Equal("Why did the chicken cross the road? to get to the othet side", joke);   
    }
}

public class MockClass : IOutJoke
{
    public string TellJoke(){
        return "Why did the chicken cross the road? to get to the othet side";
    }
}