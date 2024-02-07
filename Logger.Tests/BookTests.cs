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
        var book3 = book1 with { Id = Guid.NewGuid() };
        var book4 = book1 with { Title = "Harry Potter and the Chamber of Secretes" };

        Assert.True(book1 == book2);
        Assert.Equal(book1, book2);
        Assert.False(book1 == book3);
        Assert.False(book1.Equals(book4));

    }

}

