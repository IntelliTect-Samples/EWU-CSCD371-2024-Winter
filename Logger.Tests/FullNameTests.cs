using Xunit;

namespace Logger.Tests;

public class FullNameTests
{

    [Fact]
    public void FullName_SetValidFullName_Success()
    {
        FullName name = new("First", "Last", "Middle");
        Assert.Equal("First", name.FirstName);
        Assert.Equal("Middle", name.MiddleName);
        Assert.Equal("Last", name.LastName);
    }

    [Fact]
    public void FullName_SetValidFullNameWithNullMiddle_Success()
    {
        FullName name = new("First", "Last", null);
        Assert.Equal("First", name.FirstName);
        Assert.Empty(name.MiddleName);
        Assert.Equal("Last", name.LastName);
    }

    [Fact]
    public void ToString_NoMiddleName_ReturnsSuccessfully()
    {
        FullName fullName = new( "Demon", "Ruby");
        Assert.Equal("Demon Ruby", fullName.ToString());
    }

    [Fact]
    public void ToString_WithMiddleName_ReturnsSuccessfully()
    {
        FullName fullName = new("Shaggy", "Scooby", "Fred");
        Assert.Equal("Shaggy Fred Scooby", fullName.ToString());
    }

    [Fact]
    public void FullName_SetFullNameWithNullFirst_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new FullName(null!, "Last", null));
    }

    [Fact]
    public void FullName_SetFullNameWithNullLast_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new FullName("First", null!, "Middle"));
    }
}
