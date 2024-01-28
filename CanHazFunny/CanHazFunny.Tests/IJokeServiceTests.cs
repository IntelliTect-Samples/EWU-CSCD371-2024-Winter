using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace CanHazFunny.Tests;


public class IJokeServiceTests
{
    [Fact]
    public void GetJoke_RetriveAJocke_Success()
    {
        var mock = new Mock<IJokeService>();
        mock.Setup(x => x.GetJoke()).Returns("Here is my joke :(");
        IJokeService jokeService = mock.Object;
        var result = new MockClass().GetJoke();
        Assert.Equal(jokeService.GetJoke(), result);
    }

}

public class MockClass : IJokeService
{
    public string GetJoke()
    {
        return "Here is my joke :)";
    }
}
