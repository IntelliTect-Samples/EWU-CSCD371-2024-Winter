using Moq;
using Xunit;

namespace CanHazFunny.Tests;


public class IJokeServiceTests
{
    [Fact]
    public void GetJoke_RetrieveAJock_Success()
    {
        var mock = new Mock<IJokeService>();
        mock.Setup(x => x.GetJoke()).Returns("Here is my joke :)");
        MockClass mockClass = new();
        #pragma warning disable xUnit2006 // Do not use invalid string equality check
        Assert.Equal<string>(mock.Object.GetJoke(), mockClass.GetJoke());
        #pragma warning restore xUnit2006 // Do not use invalid string equality check

    }

    [Fact]
    public void GetJoke_RetrieveAJock_Fail()
    {
        var mock = new Mock<IJokeService>();
        mock.Setup(x => x.GetJoke()).Returns("Here is my joke :(");
        IJokeService jokeService = mock.Object;
        var result = new MockClass().GetJoke();
        Assert.NotEqual(jokeService.GetJoke(), result);
    }

}

public class MockClass : IJokeService
{
    public string GetJoke()
    {
        return "Here is my joke :)";
    }
}
