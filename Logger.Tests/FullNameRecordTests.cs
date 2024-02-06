using Xunit;

namespace Logger.Tests;

#pragma warning disable CS8625
//passing in null during tests
public class FullNameRecordTests
{
    [Fact]
    public void FullNameRecord_WithMiddleName_ShouldSetPropertiesCorrectly()
    {
        string firstName = "John";
        string lastName = "Doe";
        string middleName = "Smith";

        var fullNameRecord = new FullNameRecord(firstName, lastName, middleName);

        Assert.Equal(firstName, fullNameRecord.FirstName);
        Assert.Equal(lastName, fullNameRecord.LastName);
        Assert.Equal(middleName, fullNameRecord.MiddleName);
    }


    [Fact]
    public void FullNameRecord_WithoutMiddleName_ShouldSetMiddleNameToNull()
    {
        string firstName = "John";
        string lastName = "Doe";

        var fullNameRecord = new FullNameRecord(firstName, lastName);

        Assert.Null(fullNameRecord.MiddleName);
    }


    [Theory]
    [InlineData("John", "Doe", "Smith", "John Smith Doe")]
    [InlineData("Alice", "Johnson", null, "Alice Johnson")]
    public void ToString_MiddleNameWithValueAndNull_ShouldReturnCorrectFormat(string firstName, string lastName, string middleName, string expected)
    {
        var fullNameRecord = middleName != null ? new FullNameRecord(firstName, lastName, middleName) : new FullNameRecord(firstName, lastName);

        var result = fullNameRecord.ToString();

        Assert.Equal(expected, result);
    }

    [Fact]
        public void FullNameRecord_WithNullFirstName_ShouldThrowArgumentNullException()
        {
            // Arrange
            string firstName = null!;
            string lastName = "Doe";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FullNameRecord(firstName!, lastName));
        }

        [Fact]
        public void FullNameRecord_WithNullLastName_ShouldThrowArgumentNullException()
        {
            // Arrange
            string firstName = "John";
            string lastName = null!;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FullNameRecord(firstName, lastName!));
        }


}