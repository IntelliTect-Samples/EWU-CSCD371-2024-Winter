using Xunit;

namespace Logger.Tests;

public class BookRecordTests
{
    [Fact]
    public void BookRecord_InitializeName_Success()
    {
        BookRecord book = new(nameof(BookRecord));
        Assert.Equal(nameof(BookRecord), book.Name);
    }

    [Fact]
    public void BookRecord_SameBookEquals_Success()
    {
        BookRecord book1 = new(nameof(BookRecord));
        BookRecord book2 = book1 with { };
        Assert.True(book1.Equals(book2));   
    }

    [Fact]
    public void BookRecord_TwoBooksNotEquals_Success()
    {
        BookRecord book1 = new(nameof(BookRecord));
        BookRecord book2 = new(nameof(BookRecord));
        Assert.False(book1.Equals(book2));
    }

    [Fact]
    public void BookRecord_SetToNull_ThrowArgumentNullException() 
    {
        Assert.Throws<ArgumentNullException>(
            () => new BookRecord(null!)
        );
    }
}
