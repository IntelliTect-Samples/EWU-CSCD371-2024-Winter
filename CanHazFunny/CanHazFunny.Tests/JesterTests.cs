using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JesterTests
{
    [Fact]
    public void IServicePropertySetNullSuccessfully()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeOutput()));

    }

    [Fact]
    public void IOutputPropertySetNullSuccessfully()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));

    }

    [Fact]
    public void TellJokeChuckNorrisJokeSkipsSuccessfully()
    {
        var mockService = new Mock<IService>();
        var mockOutput = new Mock<IOutput>();

        mockService.SetupSequence(x => x.GetJoke())
                       .Returns("Chuck Norris joke")
                       .Returns("LMAO");

        var jester = new Jester(mockService.Object, mockOutput.Object);

        jester.TellJoke();

        mockService.Verify(x => x.GetJoke(), Times.Exactly(2));
        mockOutput.Verify(x => x.WriteJoke("LMAO"), Times.Once);

    }

}



