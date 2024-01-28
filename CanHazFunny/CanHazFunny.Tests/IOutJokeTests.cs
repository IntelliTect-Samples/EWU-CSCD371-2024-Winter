using Xunit;

namespace CanHazFunny.Tests;

public class IOutJokeTests
{
    [Fact]
    public void TellJoke_CallMethod_Success()
    {
        MockOutJoke mockClass = new();
        string joke = mockClass.TellJoke(); 
        Assert.Equal("Why did the chicken cross the road? to get to the othet side", joke);   
    }
}

public class MockOutJoke : IOutJoke
{
    public string TellJoke(){
        return "Why did the chicken cross the road? to get to the othet side";
    }
}