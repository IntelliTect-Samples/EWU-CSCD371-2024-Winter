﻿using Xunit;

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
        FullName fullName = new("Tom", "Scott", null);
        Student student = new(fullName);
        Assert.Equal("Tom Scott", student.Name);
    }

    [Fact]
    public void Student_InitializeStudentWithMiddleName_Success()
    {
        FullName fullName = new("First", "Last", "Middle");
        Student student = new(fullName);
        Assert.Equal("First Middle Last", student.Name);
    }

    [Fact]
    public void Student_InitialzeTwoStudentsWithSameName_NotEqual()
    {
        FullName fullName = new("First", "Last", "Middle");
        Student student = new(fullName);
        Student student1 = new(fullName);

        Assert.NotEqual(student, student1);
    }

    [Fact]
    public void Student_InitialzeStudentsWithNull_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student(new("First", null!, "Middle")));
    }

    [Fact]
    public void Student_InitialzeStudentsWithBlank_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Student(new(" ", "Last", "Middle")));
    }


    //Employee Tests ------------------------------------------
    [Fact]
    public void Employee_InitializeStudentWithoutMiddleName_Success()
    {
        FullName fullName = new("John", "Smith", null);
        Employee employee = new(fullName);
        Assert.Equal("John Smith", employee.Name);
    }

    [Fact]
    public void Employee_InitializeStudentWithMiddleName_Success()
    {
        FullName fullName = new("First", "Last", "Middle");
        Employee employee = new(fullName);
        Assert.Equal("First Middle Last", employee.Name);
    }

    [Fact]
    public void Employee_InitialzeTwoEmployeesWithSameName_NotEqual()
    {
        FullName fullName = new("First", "Last", "Middle");
        Employee employee = new(fullName);
        Employee employee1 = new(fullName);

        Assert.NotEqual(employee, employee1);
    }

    [Fact]
    public void Employee_InitialzeEmployeeWithNull_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee(new("First", null!, "Middle")));
    }

    [Fact]
    public void Employee_InitialzeEmployeeWithBlank_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Employee(new(" ", "Last", "Middle")));
    }
}
