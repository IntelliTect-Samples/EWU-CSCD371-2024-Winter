using Xunit;

namespace Logger.Tests;

public class EmployeeRecordTests {

    [Fact]
    public void EmployeeRecord_ValidName_ConstructsWithFullName()
    {
        var fullName = new FullNameRecord("John", "Doe");
        
        var employee = new EmployeeRecord(fullName);
        
        Assert.NotNull(employee);
        Assert.Equal("John Doe", employee.Name);
    }

    [Fact]
        public void EmployeeRecord_FullName_ConvertsToString()
        {
            var fullName = new FullNameRecord("Jane", "Smith", "Doe");
            var employee = new EmployeeRecord(fullName);

            var result = employee.ToString();

            Assert.Equal("Jane Doe Smith", result);
        }


}