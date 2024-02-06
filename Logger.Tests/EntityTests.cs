using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class EntityTests
{
    //Book Tests ------------------------------------------
    [Fact]
    public void Book_InitialzeBookWithTitle_Success()
    {
        string title = "Lord of the Flies";
        Book book1 = new(title);

        Assert.Equal(title, book1.Name);
    }

    [Fact]
    public void Book_InitialzeTwoBookWithSameTitle_NotEqual()
    {
        string title = "Lord of the Flies";
        Book book1 = new(title);
        Book book2 = new(title);

        Assert.NotEqual(book1, book2);
    }
    
    [Fact]
    public void Book_InitialzeBookWithNullTitle_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Book(null!));
    }

    [Fact]
    public void Book_InitialzeBookWithBlankTitle_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Book(" "));
    }

    //Student Tests ------------------------------------------
    [Fact]
    public void Student_InitializeStudentWithoutMiddleName_Success()
    {
        FullName fullName = new("Tom", null, "Scott");
        Student student = new(fullName);
        Assert.Equal("Tom Scott", student.Name);
    }

    [Fact]
    public void Student_InitializeStudentWithMiddleName_Success()
    {
        FullName fullName = new("First", "Middle", "Last");
        Student student = new(fullName);
        Assert.Equal("First Middle Last", student.Name);
    }

    //Still need error tests...

    //Employee Tests ------------------------------------------
    [Fact]
    public void Employee_InitializeStudentWithoutMiddleName_Success()
    {
        FullName fullName = new("John", null, "Smith");
        Employee employee = new(fullName);
        Assert.Equal("John Smith", employee.Name);
    }

    [Fact]
    public void Employee_InitializeStudentWithMiddleName_Success()
    {
        FullName fullName = new("First", "Middle", "Last");
        Employee employee = new(fullName);
        Assert.Equal("First Middle Last", employee.Name);
    }

    //Still need error tests...
}
