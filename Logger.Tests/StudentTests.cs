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

    [Fact]
        public void Student_FullName_ConvertsToString()
        {
            var fullName = new FullNameRecord("Jane", "Smith", "Doe");
            var student = new StudentRecord(fullName);
    
            var result = student.ToString();
         
            Assert.Equal("Jane Doe Smith", result);
        }


    







}