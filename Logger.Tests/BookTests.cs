using Xunit;

namespace Logger.Tests;

public class BookTests
{
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Book_NullTitle_ThrowsNullPointerException() {
        Assert.Throws<ArgumentNullException>(() => new Book(null,1231231231234));
    }

    [Fact]
    public void Book_NullIsbn_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Book("Essential C#", null));
    }

    #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.


    [Fact]
    public void Book_ValidBook_ReturnsFormattedName()
    {
        Guid testGuid = Guid.NewGuid();
        var book = new Book("Essential C#", 1231231231234)
        {
            Id = testGuid,
        };
        Assert.Equal($"EntityType: Book, EntityID: {testGuid}, Title: Essential C#, ISBN: 1231231231234", book.Name);
    }

    [Fact]
    public void ToString_ValidBook_ReturnsCorrectFormat()
    {
        var book = new Book("Essential C#", 1231231231234);
        Assert.Equal("Title: Essential C#, ISBN: 1231231231234", book.ToString());
    }


    [Fact]
    public void Equals_SameArthorAndTitle_ReturnsTrue()
    {
        Guid testGuid = Guid.NewGuid();
        var book1 = new Book("Harry Potter and the Goblet of Fire", 5683382947580) 
        { 
            Id = testGuid,
        };
        var book2 = new Book("Harry Potter and the Goblet of Fire", 5683382947580)
        {
            Id = testGuid,
        };

        Assert.True(book1 == book2);
        Assert.Equal(book1, book2);

    }

    [Fact]
    public void Equals_DifferntEmployeeProperties_ReturnsFalse()
    {
        var book = new Book("Be More Chill", 1238904534383)
        {
            Id = Guid.NewGuid(),
        };

        Book bookDifferentTitle = book with { Title = "Planets of the Apes", };
        Book bookDifferentId = book with { Id = Guid.NewGuid(), };
        Book bookDifferentIsbn = book with { Isbn = 2938492740452 };

        Assert.False(book.Equals(bookDifferentTitle));
        Assert.False(book == bookDifferentId);
        Assert.NotEqual(book, bookDifferentIsbn);


    }

}

