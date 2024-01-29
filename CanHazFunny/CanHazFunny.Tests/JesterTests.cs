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

}



