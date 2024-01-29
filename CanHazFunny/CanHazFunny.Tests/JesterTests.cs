using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JesterTests
{
    [Fact]
    public void IServiceProperty_SetNullSuccessfully()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeOutput()));

    }

    [Fact]
    public void IOutputProperty_SetNullSuccessfully()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));

    }

}



