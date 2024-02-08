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
        Assert.Null(name.MiddleName);
        Assert.Equal("Last", name.LastName);
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
