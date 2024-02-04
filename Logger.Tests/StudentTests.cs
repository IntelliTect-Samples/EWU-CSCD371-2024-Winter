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

    [Fact]
    public void Equals_SameNameAndID_ReturnsTrue()
    {
        var student1 = new Student("James", "Baily", 134567);
        var student2 = new Student("James", "Baily", 134567);

        Assert.True(student1.Equals(student2));
        Assert.True(student1 == student2);

    }

}

