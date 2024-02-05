using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class EntityTests
{
    [Fact]
    public void Book_Creation_Success()
    {
        Guid id = Guid.NewGuid();
        string title = "Lord of the Things";

        Book book = new(id, title);

        Assert.Equal(title, book.Title);
        Assert.Equal(id, book.Id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateBook_InvalidData_Fails(string title)
    {
        Guid id = Guid.NewGuid();

        //Act & Assert
        Exception ex = Assert.Throws<ArgumentException>(() => new Book(id, title));
    }

    [Fact]
    public void Student_Creation_Success()
    {
        Guid id = Guid.NewGuid();
        string firstName = "Ethan";
        string middleName = "Alexander";
        string lastName = "Guerin";

        Student student = new(id, Name.Create(firstName, middleName, lastName));

        Assert.Equal(firstName, student.FullName.FirstName);
        Assert.Equal(middleName, student.FullName.MiddleName);
        Assert.Equal(lastName, student.FullName.LastName);
        Assert.Equal(id, student.Id);
    }

    [Theory]
    [InlineData(null, "Alexander", "Guerin")]
    [InlineData("Ethan", "Alexander", null)]
    [InlineData("", "Alexander", "Guerin")]
    [InlineData("Ethan", "Alexander", "")]
    public void Student_InvalidData_ThrowError(string firstName, string? middleName, string lastName)
    {
        Guid id = Guid.NewGuid();
        Exception ex = Assert.Throws<ArgumentException>(() => new Student(id, Name.Create(firstName, middleName, lastName)));
    }

    [Fact]
    public void Employee_Creation_Success()
    {
        Guid id = Guid.NewGuid();
        string firstName = "Ethan";
        string middleName = "Alexander";
        string lastName = "Guerin";

        Employee employee = new(id, Name.Create(firstName, middleName, lastName));

        Assert.Equal(firstName, employee.FullName.FirstName);
        Assert.Equal(middleName, employee.FullName.MiddleName);
        Assert.Equal(lastName, employee.FullName.LastName);
        Assert.Equal(id, employee.Id);
    }

    [Theory]
    [InlineData(null, "Alexander", "Guerin")]
    [InlineData("Ethan", "Alexander", null)]
    [InlineData("", "Alexander", "Guerin")]
    [InlineData("Ethan", "Alexander", "")]
    public void Employee_InvalidData_ThrowsError(string firstName, string? middleName, string lastName)
    {
        Guid id = Guid.NewGuid();
        Exception ex = Assert.Throws<ArgumentException>(() => new Employee(id, Name.Create(firstName, middleName, lastName)));
    }
}
