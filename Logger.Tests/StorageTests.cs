using Xunit;
namespace Logger.Tests;

public class StorageTests
{
    public StorageTests()
    {
        Storage storage = new();
    }

    //Student
    [Fact]
    public void Add_Student_ContainsStudent()
    {
        Student student = new(new FullName("First", "Middle", "Last"));
        storage.Add(student);
        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void Remove_Student_DoesNotContainStudent()
    {
        Student student = new(new FullName("First", "Middle", "Last"));
        storage.Add(student);
        storage.Remove(student);
        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Get_Student_ReturnsStudentsID()
    {
        Student student = new(new FullName("First", "Middle", "Last"));
        storage.Add(student);
        Assert.Equal(student, storage.Get(student.Id));
    }

    //Employee
    [Fact]
    public void Add_Employee_ContainsEmployee()
    {
        
        Employee employee = new(new FullName("First", "Middle", "Last"));
        storage.Add(employee);
        Assert.True(storage.Contains(employee));
    }

    [Fact]
    public void Remove_Employee_DoesNotContainEmployee()
    {
        
        Employee employee = new(new FullName("First", "Middle", "Last"));
        storage.Add(employee);
        storage.Remove(employee);
        Assert.False(storage.Contains(employee));
    }

    [Fact]
    public void Get_Employee_ReturnsEmployeesID()
    {
        
        Employee employee = new(new FullName("First", "Middle", "Last"));
        storage.Add(employee);
        Assert.Equal(employee, storage.Get(employee.Id));
    }
    //Book
    [Fact]
    public void Add_Book_ContainsBook()
    {
        
        Book book = new("Title");
        storage.Add(book);
        Assert.True(storage.Contains(book));
    }

    [Fact]
    public void Remove_Book_DoesNotContainBook()
    {
        
        Book book = new("Title");
        storage.Add(book);
        storage.Remove(book);
        Assert.False(storage.Contains(book));
    }

    [Fact]
    public void Get_Book_ReturnsBooksID()
    {
        
        Book book = new("Title");
        storage.Add(book);
        Assert.Equal(book, storage.Get(book.Id));
    }
}
