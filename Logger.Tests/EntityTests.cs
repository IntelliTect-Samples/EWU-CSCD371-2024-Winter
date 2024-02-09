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

        Assert.NotEqual(book1.ID, book2.ID);
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

        Assert.Equal(book1.ID, book2.ID);
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
        FullName fullName = new("Bobby", "Singer", "Idjit");
        Student student = new(fullName);
        Assert.Equal("Bobby Idjit Singer", student.Name);
    }

    [Fact]
    public void Student_InitialzeTwoStudentsWithSameNameDiffId_NotEqual()
    {
        FullName fullName = new("Kevin", "Tran", "Prophet");
        Student student = new(fullName);
        Student student1 = new(fullName);

        Assert.NotEqual(student, student1);
    }

    [Fact]
    public void Student_InitialzeTwoStudentsWithSameNameSameId_Equal()
    {
        FullName fullName = new("Richie", "Jerimovich", "VanHalen");
        Guid id = Guid.NewGuid();
        Student student = new(fullName)
        {
            ID = id,
        };
        Student student1 = new(fullName)
        {
            ID = id,
        };

        Assert.Equal(student.ID, student1.ID);
    }

    [Fact]
    public void Student_InitialzeStudentsFirstNameWithNull_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student(new(null!, "Chef", "Marcus")));
    }

    [Fact]
    public void Student_InitialzeStudentsLastNameWithNull_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student(new("Chef", null!, "Terry")));
    }

    [Fact]
    public void Student_InitialzeStudentsFirstNameWithBlank_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Student(new(" ", "Michael", "Berzatto")));
    }

    [Fact]
    public void Student_InitialzeStudentsLastNameWithBlank_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Student(new("Angel", " ", "Castiel")));
    }


    //Employee Tests ------------------------------------------
    [Fact]
    public void Employee_InitializeEmployeeWithoutMiddleName_Success()
    {
        FullName fullName = new("John", "Smith", null);
        Employee employee = new(fullName);
        Assert.Equal("John Smith", employee.Name);
    }

    [Fact]
    public void Employee_InitializeEmployeeWithMiddleName_Success()
    {
        FullName fullName = new("Jimmy", "Kalinowski", "Cicero");
        Employee employee = new(fullName);
        Assert.Equal("Jimmy Cicero Kalinowski", employee.Name);
    }

    [Fact]
    public void Employee_InitialzeTwoEmployeesWithSameNameDiffId_NotEqual()
    {
        FullName fullName = new("Neil", "Fak", "Fixer");
        Employee employee = new(fullName);
        Employee employee1 = new(fullName);

        Assert.NotEqual(employee.ID, employee1.ID);
    }

    [Fact]
    public void Employee_InitialzeTwoEmployeesWithSameNameSameId_Equal()
    {
        FullName fullName = new("Sydney", "Adamu", "Chef");
        Guid id = Guid.NewGuid();
        Employee employee = new(fullName)
        {
            ID = id,
        };
        Employee employee1 = new(fullName)
        {
            ID = id,
        };

        Assert.Equal(employee.ID, employee1.ID);
    }
    [Fact]
    public void Employee_InitialzeEmployeeFirstNameWithNull_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee(new(null!, "Archangel", "Gabriel")));
    }

    [Fact]
    public void Employee_InitialzeEmployeeLastNameWithNull_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new Employee(new("Chef", null!, "Ebraheim")));
    }

    [Fact]
    public void Employee_InitialzeEmployeeFirstNameWithBlank_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Employee(new(" ", "Chef", "Tina")));
    }

    [Fact]
    public void Employee_InitialzeEmployeeLastNameWithBlank_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Employee(new("King", " ", "Crowley")));
    }
}
