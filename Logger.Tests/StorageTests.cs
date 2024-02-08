using Xunit;
namespace Logger.Tests;

public class StorageTests
{
     
     public Storage Storage {get; set;}
     public void StorageTests(){
            Storage = new Storage();
     
     }
    //Student
    [Fact]
    public void Add_Student_ContainsStudent()
    {
        Storage storage = new();
        Student student = new(new FullName("First", "Middle", "Last"));
        storage.Add(student);
        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void Remove_Student_DoesNotContainStudent()
    {
        Storage storage = new();
        Student student = new(new FullName("First", "Middle", "Last"));
        storage.Add(student);
        storage.Remove(student);
        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Get_Student_ReturnsStudentsID()
    {
        Storage storage = new();
        Student student = new(new FullName("First", "Middle", "Last"));
        storage.Add(student);
        Assert.Equal(student, storage.Get(student.Id));
    }

    //Employee
    [Fact]
    public void Add_Employee_ContainsEmployee()
    {
        Storage storage = new();
        Employee employee = new(new FullName("First", "Middle", "Last"));
        storage.Add(employee);
        Assert.True(storage.Contains(employee));
    }

    [Fact]
    public void Remove_Employee_DoesNotContainEmployee()
    {
        Storage storage = new();
        Employee employee = new(new FullName("First", "Middle", "Last"));
        storage.Add(employee);
        storage.Remove(employee);
        Assert.False(storage.Contains(employee));
    }

    [Fact]
    public void Get_Employee_ReturnsEmployeesID()
    {
        Storage storage = new();
        Employee employee = new(new FullName("First", "Middle", "Last"));
        storage.Add(employee);
        Assert.Equal(employee, storage.Get(employee.Id));
    }
    //Book
    [Fact]
    public void Add_Book_ContainsBook()
    {
        Storage storage = new();
        Book book = new("Title");
        storage.Add(book);
        Assert.True(storage.Contains(book));
    }

    [Fact]
    public void Remove_Book_DoesNotContainBook()
    {
        Storage storage = new();
        Book book = new("Title");
        storage.Add(book);
        storage.Remove(book);
        Assert.False(storage.Contains(book));
    }

    [Fact]
    public void Get_Book_ReturnsBooksID()
    {
        Storage storage = new();
        Book book = new("Title");
        storage.Add(book);
        Assert.Equal(book, storage.Get(book.Id));
    }
}
