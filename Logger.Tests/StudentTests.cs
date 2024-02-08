using Xunit;

namespace Logger.Tests;

public class StudentTests {

    [Fact]
    public void Student_ValidName_ConstructsWithFullName()
    {
        var fullName = new FullNameRecord("John", "Doe");
     
        var student = new StudentRecord(fullName);
       
        Assert.NotNull(student);
        Assert.Equal("John Doe", student.Name);
    }



    







}