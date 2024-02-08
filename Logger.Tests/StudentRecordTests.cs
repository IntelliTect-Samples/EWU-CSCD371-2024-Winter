using Xunit;

namespace Logger.Tests;

public class StudentRecordTests {

    [Fact]
    public void StudentRecord_ValidName_ConstructsWithFullName()
    {
        var fullName = new FullNameRecord("John", "Doe");
     
        var student = new StudentRecord(fullName);
       
        Assert.NotNull(student);
        Assert.Equal("John Doe", student.Name);
    }

    [Fact]
    public void StudentRecord_FullName_ConvertsToString()
    {
        var fullName = new FullNameRecord("Jane", "Smith", "Doe");
        var student = new StudentRecord(fullName);

        var result = student.ToString();
        
        Assert.Equal("Jane Doe Smith", result);
    }


    







}