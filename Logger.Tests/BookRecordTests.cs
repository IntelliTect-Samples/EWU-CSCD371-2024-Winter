using Xunit;

namespace Logger.Tests;

public class BookRecordTests {

    [Fact]
    public void BookRecord_ValidValues_ConstructsSuccessfully()
    {
        string author = "John Doe";
        string title = "Sample Book";
        int isbn = 1234567890;

        var book = new BookRecord(author, title, isbn);

        Assert.NotNull(book);
        Assert.Equal(author, book.Author);
        Assert.Equal(title, book.Title);
        Assert.Equal(isbn, book.Isbn);
    }

    [Fact]
    public void BookRecord_Name_ReturnsCorrectValue()
    {
        string author = "John Doe";
        string title = "Sample Book";
        var expectedName = $"BookRecord:{author}, {title}";

        var book = new BookRecord(author, title, 1234567890);

        Assert.Equal(expectedName, book.Name);
    }

    [Fact]
    public void BookRecord_ToString_ReturnsCorrectString()
    {
        string author = "John Doe";
        string title = "Sample Book";
        int isbn = 1234567890;
        var expectedString = $"{author}, {title} - ISBN: {isbn}";

        var book = new BookRecord(author, title, isbn);

        Assert.Equal(expectedString, book.ToString());
    }


    [Fact]
    public void BookRecord_NullAuthor_ThrowNullException()
    {
        string title = "Sample Book";
        int isbn = 1234567890;

        Assert.Throws<ArgumentNullException>(() => new BookRecord(null!, title, isbn));
    }


    [Fact]
    public void BookRecord_NullTitle_ThrowsNullException()
    {
        string author = "John Doe";
        int isbn = 1234567890;

        Assert.Throws<ArgumentNullException>(() => new BookRecord(author, null!, isbn));
    }


    


}