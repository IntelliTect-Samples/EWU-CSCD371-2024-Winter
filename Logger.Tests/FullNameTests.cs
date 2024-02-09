using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Theory]
    [InlineData("First", "Last", "Middle", "First Middle Last")]
    [InlineData("First", "Last", null, "First Last")]
    public void FullName_ToString_HandlesNullMiddle(string first, string? middle, string last, string expects)
    {
        FullName name = new(first, middle,last);
        Assert.Equal(expects, name.ToString());
    }

    [Fact]
    public void FullName_ToString_HandlesOptionalMiddle()
    {
        FullName name = new("First",null, "Last");
        Assert.Equal("First Last", name.ToString());
    }

    [Theory]
    [InlineData("First", "Last", "Middle")]
    [InlineData("First", "Last", null)]
    public void FullName_Deconstruct_Successful(string first, string? middle, string last)
    {
        FullName name = new(first, middle, last);
        (string firstDeconst, string? middleDeconst, string lastDeconst) = name;
        Assert.Equal(first, firstDeconst);
        Assert.Equal(last, lastDeconst);
        Assert.Equal(middle, middleDeconst);
    }
}

