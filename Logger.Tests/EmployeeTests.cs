using Xunit;

namespace Logger.Tests;

    public class EmployeeTests
    {
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Employee_NullFirstname_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee(null, "Davis", 11123));
    }

    [Fact]
    public void Employee_NullLastName_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee("John", null, 11123));
    }
    [Fact]
    public void Employee_NullEmployeeID_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee("John", "Davis", null));
    }


    [Fact]
    public void EmployeeName_ValidEmployee_ReturnsFormattedName()
    {
        Guid testGuid = Guid.NewGuid();
        IEntity employee = new Employee("John", "Davis", 11123)
        {
            Id = testGuid,
        };

        Assert.Equal($"EntityType: Employee, EntityID: {testGuid}, Name: John Davis, EmployeeID: 11123", employee.Name);
    }

    [Fact]
    public void ToString_ValidEmployee_ReturnsCorrectFormat()
    {
        Employee emp = new("Jack", "White", 11123);

        Assert.Equal("Name: Jack White, EmployeeID: 11123", emp.ToString());
    }

    [Fact]
    public void Equals_SameNameAndSalary_ReturnsTrue()
    {
        Guid entityID = Guid.NewGuid();
        var employee1 = new Employee("Thomas", "Young", 11123) { 
            Id = entityID,
        };
        var employee2 = new Employee("Thomas", "Young", 11123)
        {
            Id = entityID,
        }
;

        var employee3 = employee1 with { Id = Guid.NewGuid(), };
        var employee4 = employee1 with { LastName = "Salazar" };

        Assert.True(employee1.Equals(employee2));
        Assert.True(employee1 == employee2);
        Assert.False(employee1 == employee3);
        Assert.False(employee1.Equals(employee4));


    }

}

