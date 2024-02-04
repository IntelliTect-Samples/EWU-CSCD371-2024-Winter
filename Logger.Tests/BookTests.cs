

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
    public void Book_ValidBook_ReturnsFormattedName()
    {
        var book = new Book("Essential C#", "Mark Michaelis");
        Assert.Equal("Book: Essential C# By Mark Michaelis", book.Name);
    }

    [Fact]
    public void Equals_SameArthorAndTitle_ReturnsTrue()
    {
        var book1 = new Book("Harry Potter and the Goblet of Fire", "JK Rowling");
        var book2 = new Book("Harry Potter and the Goblet of Fire", "JK Rowling");

        Assert.True(book1 == book2);
        Assert.Equal(book1, book2);

    }

}

