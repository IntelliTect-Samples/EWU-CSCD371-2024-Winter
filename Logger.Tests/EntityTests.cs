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
    public void Book_InitialzeTwoBookWithSameTitleDiffId_NotEqual()
    {
        string title = "Lord of the Flies";
        Book book1 = new(title);
        Book book2 = new(title);

        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Book_InitialzeTwoBookWithSameTitleSameId_Equal()
    {
        string title = "Lord of the Flies";
        Guid id = Guid.NewGuid();
        Book book1 = new(title)
        {
            ID = id,
        };
        Book book2 = new(title)
        {
            ID = id,
        };

        Assert.Equal(book1, book2);
    }

    [Fact]
    public void Book_InitialzeBookWithNullTitle_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Book(null!));
    }

    [Fact]
    public void Book_InitialzeBookWithBlankTitle_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Book(""));
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
    public void Student_InitialzeTwoStudentsWithSameNameDiffId_NotEqual()
    {
        FullName fullName = new("First", "Last", "Middle");
        Student student = new(fullName);
        Student student1 = new(fullName);

        Assert.NotEqual(student, student1);
    }

    [Fact]
    public void Student_InitialzeTwoStudentsWithSameNameSameId_Equal()
    {
        FullName fullName = new("First", "Last", "Middle");
        Guid id = Guid.NewGuid();
        Student student = new(fullName)
        {
            ID = id,
        };
        Student student1 = new(fullName)
        {
            ID = id,
        };

        Assert.Equal(student, student1);
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
    public void Employee_InitialzeTwoEmployeesWithSameNameDiffId_NotEqual()
    {
        FullName fullName = new("First", "Last", "Middle");
        Employee employee = new(fullName);
        Employee employee1 = new(fullName);

        Assert.NotEqual(employee, employee1);
    }

    [Fact]
    public void Employee_InitialzeTwoEmployeesWithSameNameSameId_Equal()
    {
        FullName fullName = new("First", "Last", "Middle");
        Guid id = Guid.NewGuid();
        Employee employee = new(fullName)
        {
            ID = id,
        };
        Employee employee1 = new(fullName)
        {
            ID = id,
        };

        Assert.Equal(employee, employee1);
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
