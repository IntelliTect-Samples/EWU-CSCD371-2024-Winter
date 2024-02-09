using Xunit;

namespace Logger.Tests;

public class StudentRecordTests
{
    [Fact]
    public void StudentRecord_GetClassName_Success()
    {
        StudentRecord studentRecord = new(nameof(StudentRecord));
        Assert.Equal(nameof(StudentRecord), studentRecord.Name);
    }

    [Fact]
    public void StudentRecord_GetClassNameWithFullName_Success()
    {
        FullNameRecord fullName = new("Inigo", "Montoya", "Alex");
        StudentRecord studentRecord = new(nameof(StudentRecord), fullName);
        Assert.Equal(nameof(StudentRecord), studentRecord.Name);
    }

    [Fact]
    public void StudentRecord_SameStudentEquals_Success()
    {
        StudentRecord student1 = new(nameof(StudentRecord));
        StudentRecord student2 = student1 with {};
        Assert.True(student1.Equals(student2));
    }

    [Fact]
    public void StudentRecord_TwoStudentsNotEqual_Success()
    {
        StudentRecord student1 = new(nameof(StudentRecord));
        StudentRecord student2 = new(nameof(StudentRecord));
        Assert.False(student1.Equals(student2));
    }
}
