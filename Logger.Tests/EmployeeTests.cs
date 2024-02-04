

using Xunit;

namespace Logger.Tests;

    public class EmployeeTests
    {
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Employee_NullFirstname_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee(null, "Davis"));
    }

    [Fact]
    public void Employee_NullLastName_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee("John", null));
    }

    [Fact]
    public void EmployeeName_ValidEmployee_ReturnsFormattedName()
    {
        IEntity employee = new Employee("John", "Davis");

        Assert.Equal("Employee: John Davis", employee.Name);
    }

    [Fact]
    public void Equals_SameNameAndSalary_ReturnsTrue()
    {
        var employeeGuid  = Guid.NewGuid();

        var employee1 = new Employee("Thomas", "Young")
        {
            Id = employeeGuid
        };
        var employee2 = new Employee("Thomas", "Young")
        {
            Id = employeeGuid

        };
        Console.WriteLine(employee1 + " " + employee2);
        Assert.True(employee1.Equals(employee2));
        Assert.True(employee1 == employee2);

    }

}

