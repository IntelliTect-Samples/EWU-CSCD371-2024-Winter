using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests;


public class JesterTests
{
    [Fact]
    public void IServiceProperty_SetNull_Successfully()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeOutput()));

    }

    [Fact]
    public void IOutputProperty_SetNull_Successfully()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null!));

    }

}



