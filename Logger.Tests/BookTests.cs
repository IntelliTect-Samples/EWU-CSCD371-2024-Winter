

using Xunit;

namespace Logger.Tests;

public class BookTests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Book_NullTitle_ThrowsNullPointerException() {
        Assert.Throws<ArgumentNullException>(() => new Book(null, "Mark Michaelis"));
    }

    [Fact]
    public void Book_NullAuthor_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Book("Essential C#", null));
    }

    [Fact]
    public void Book_CorrectAuthorAndTitle_ReturnsFormattedName()
    {
        var book = new Book("Essential C#", "Mark Michaelis");
        Assert.Equal("Essential C#: Mark Michaelis", book.Name);
    }
    
    }

