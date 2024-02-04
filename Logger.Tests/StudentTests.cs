using Xunit;

namespace Logger.Tests;

    public class StudentTests
    {
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Student_NullFirstname_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(()=> new Student(null, "Robertson", 1345));
    }

    [Fact]
    public void Student_NullLastName_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student("Jeffrey", null, 1345));
    }

    [Fact]
    public void ToString_ValidStudent_ReturnsFormattedName()
    {
        var student = new Student("Jeffrey", "Robertson", 1345);

        Assert.Equal("1345: Jeffrey Robertson", student.Name);
    }
}

