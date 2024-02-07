using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Logger.Tests;

public class TestRecords
{
    [Theory]
    [InlineData("The Princess Bride", "William Goldman")]
    [InlineData("Fear and Loathing in Las Vegas", "Hunter S. Thompson")]
    [InlineData("2001: A Space Odysssey", "Arthur C. Clarke")]
    public void TestBookRecords(string bookName, string author)
    {
        BookRecord book = new(bookName, author);
        BookRecord alsoBook = book;
        BookRecord book2 = new(bookName, author);
        Assert.Equal(bookName, book.Name);
        Assert.Equal(author, book.Author);
        Assert.True(book.Equals(alsoBook));
        Assert.NotEqual(book.Id, book2.Id);
    }

    [Theory]
    [InlineData("Inigo Montoya", "Fencing")]
    [InlineData("Wesley", "Piracy")]
    public void TestStudentRecords(string name, string major)
    {
        StudentRecord student = new(name, major);
        Assert.Equal(name, student.Name);
        Assert.Equal(major, student.Major);
        Assert.True(student.Equals(student));
        Assert.False(student.Equals(new StudentRecord(name, major)));
    }

    [Theory]
    [InlineData("Inigo Montoya", 15.00)]
    [InlineData("Wesley", 20.00)]
    public void TestEmployeeRecords(string name, decimal wage)
    {
        EmployeeRecord employee = new(name, wage);
        Assert.Equal(name, employee.Name);
        Assert.Equal(wage, employee.Wage);
        Assert.True(employee.Equals(employee));
        Assert.False(employee.Equals(new EmployeeRecord(name, wage)));
    }
}

