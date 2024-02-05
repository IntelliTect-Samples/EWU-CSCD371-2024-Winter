

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
    public void ToString_ValidEmployee_ReturnsCorrectFormat()
    {
        Employee emp = new("Jack", "White");

        Assert.Equal("Jack White", emp.ToString());
    }

    [Fact]
    public void Equals_SameNameAndSalary_ReturnsTrue()
    {
        var employee1 = new Employee("Thomas", "Young");
        var employee2 = new Employee("Thomas", "Young");

        var employee3 = employee1 with { LastName = "Salazare" };
        Assert.True(employee1.Equals(employee2));
        Assert.True(employee1 == employee2);
        Assert.False(employee1 == employee3);


    }

}

