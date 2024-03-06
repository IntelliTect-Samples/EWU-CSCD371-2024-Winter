using System;
using Xunit;

namespace Assignment.Tests;
public class SampleDataTests
{
    [Fact]
    public void SampleTest()
    {
        string str = "meow";
        Assert.Equal("meow", str);
    }
}



