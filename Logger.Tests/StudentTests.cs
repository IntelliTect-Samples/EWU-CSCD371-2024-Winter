using Xunit;

namespace Logger.Tests;

    public class StudentTests
    {
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Student_NullId_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(()=> new Student("Jeffrey Robertson", null));
    }
    }

