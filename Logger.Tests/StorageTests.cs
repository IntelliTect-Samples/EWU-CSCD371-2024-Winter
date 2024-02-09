using Xunit;
namespace Logger.Tests;

public class StorageTests
{
    public Storage Storage { get; set; }
    public StorageTests()
    {
        Storage = new();
    }

    //Student
    [Fact]
    public void Add_Student_ContainsStudent()
    {
        Student student = new(new FullName("Dean", "Winchester", null));
        Storage.Add(student);
        Assert.True(Storage.Contains(student));
    }

    [Fact]
    public void Remove_Student_DoesNotContainStudent()
    {
        Student student = new(new FullName("Samuel", "Winchester", "Mike"));
        Storage.Add(student);
        Storage.Remove(student);
        Assert.False(Storage.Contains(student));
    }

    [Fact]
    public void Get_Student_ReturnsStudentsID()
    {
        Student student = new(new FullName("John", "Winchester", "Curt"));
        Storage.Add(student);
        Assert.Equal(student, Storage.Get(student.ID));
    }

    //Employee
    [Fact]
    public void Add_Employee_ContainsEmployee()
    {
        
        Employee employee = new(new FullName("Mary", "Winchester", "Rose"));
        Storage.Add(employee);
        Assert.True(Storage.Contains(employee));
    }

    [Fact]
    public void Remove_Employee_DoesNotContainEmployee()
    {
        
        Employee employee = new(new FullName("Carmen", "Berzatto", "Bear"));
        Storage.Add(employee);
        Storage.Remove(employee);
        Assert.False(Storage.Contains(employee));
    }

    [Fact]
    public void Get_Employee_ReturnsEmployeesID()
    {
        
        Employee employee = new(new FullName("Natalie", "Berzatto", "Sugar"));
        Storage.Add(employee);
        Assert.Equal(employee, Storage.Get(employee.ID));
    }
    //Book
    [Fact]
    public void Add_Book_ContainsBook()
    {
        
        Book book = new("War and Peace");
        Storage.Add(book);
        Assert.True(Storage.Contains(book));
    }

    [Fact]
    public void Remove_Book_DoesNotContainBook()
    {
        
        Book book = new("Moby Dick");
        Storage.Add(book);
        Storage.Remove(book);
        Assert.False(Storage.Contains(book));
    }

    [Fact]
    public void Get_Book_ReturnsBooksID()
    {
        
        Book book = new("Farenheit 451");
        Storage.Add(book);
        Assert.Equal(book, Storage.Get(book.ID));
    }
}
