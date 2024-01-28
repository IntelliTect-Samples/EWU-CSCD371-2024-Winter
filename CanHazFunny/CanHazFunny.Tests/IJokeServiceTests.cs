using Moq;
using Xunit;

namespace CanHazFunny.Tests;


public class IJokeServiceTests
{
    [Fact]
    public void GetJoke_RetriveAJocke_Success()
    {
        var mock = new Mock<IJokeService>();
        mock.Setup(x => x.GetJoke()).Returns("Here is my joke :)");
        MockClass mockClass = new();
        Assert.Equal(mock.Object.GetJoke(), mockClass.GetJoke());
    }

    [Fact]
    public void GetJoke_RetriveAJocke_Fail()
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
