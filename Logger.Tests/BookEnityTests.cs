

using Xunit;

namespace Logger.Tests;

    public class BookTests
    {
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void BookEnity_NullTitle_ThrowsNullPointerException() {
        Assert.Throws<ArgumentNullException>(() => new Book(null, "Mark Michaelis"));
    }

    }

