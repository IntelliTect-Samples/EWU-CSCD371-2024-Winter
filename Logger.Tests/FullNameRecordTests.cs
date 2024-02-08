using Xunit;

namespace Logger.Tests;

public class FullNameRecordTests
{
    [Fact]
    public void FullName_SetRecordToNull_Suceess()
    {
        Assert.Throws<ArgumentNullException>(
            () => new FullNameRecord(null!, null!, null) );
    }

    [Fact]
    public void FullName_RecordInitialized_Success()
    {
        string First = "Inigo";
        string Last = "Montoya";
        string Middle = "Alex";

        FullNameRecord fullName = new(First, Last, Middle);
        Assert.Equal($"{First} {Middle} {Last}", fullName.ToString());
    }

    [Fact]
    public void FullName_OptionalMiddle_Sucess()
    {

        string First = "Inigo";
        string Last = "Montoya";
        string? Middle = null;

        FullNameRecord fullName = new(First, Last, Middle);
        Assert.Equal($"{First} {Last}", fullName.ToString());
    }
}
