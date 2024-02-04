

using Xunit;

namespace Logger.Tests;

    public class EmployeeTests
    {
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Employee_NullFirstname_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee(null, "Davis", 56000.0));
    }

    [Fact]
    public void Employee_NullLastName_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee("John", null, 56000.0));
    }

    [Fact]
    public void ToString_ValidStudent_ReturnsFormattedName()
    {
        var employee = new Employee("John", "Davis", 56000.0);

        Assert.Equal("John Davis, Salary: 56000", employee.Name);
    }

    [Fact]
    public void Equals_SameNameAndSalary_ReturnsTrue()
    {
        var employee1 = new Employee("Thomas", "Young", 35000.0);
        var employee2 = new Employee("Thomas", "Young", 35000.0);

        Assert.True(employee1.Equals(employee2));
        Assert.True(employee1 == employee2);

    }

}

