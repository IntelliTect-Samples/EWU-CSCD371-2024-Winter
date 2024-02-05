using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logger.Name;
using Xunit;

namespace Logger.Tests;

public class NameTests
{
    [Fact]
    public void Create_ValidName_ReturnsFullNameInstance()
    {
        //Arrange
        string firstName = "Ethan";
        string? middleName = "Alexander";
        string lastName = "Guerin";

        //Act
        Name fullName = Create(firstName, middleName, lastName);

        //Assert
        Assert.NotNull(fullName);
        Assert.Equal(firstName, fullName.FirstName);
        Assert.Equal(middleName, fullName.MiddleName);
        Assert.Equal(lastName, fullName.LastName);

    }
    [Fact]
    public void Create_NoMiddleName_ReturnsFullNameInstance()
    {
        //Arrange
        string firstName = "Ethan";
        string lastName = "Guerin";

        //Act
        Name fullName = Create(firstName, "", lastName);
        
        //Assert
        Assert.NotNull(fullName);
        Assert.Equal(firstName, fullName.FirstName);
        Assert.Equal(lastName, fullName.LastName);

    }

    [Fact]
    public void Create_NullMiddleName_ReturnsFullNameInstance()
    {
        //Arrange
        string firstName = "Ethan";
        string middleName = null!;
        string lastName = "Guerin";

        //Act
        Name fullName = Create(firstName, middleName, lastName);

        //Assert
        Assert.NotNull(fullName);
        Assert.Equal(firstName, fullName.FirstName);
        Assert.Equal(lastName, fullName.LastName);
        Assert.Null(fullName.MiddleName);

    }

    [Theory]
    [InlineData(null, "Alexander", "Guerin")]
    [InlineData("Ethan", "Alexander", null)]
    [InlineData("", "Alexander", "Guerin")]
    [InlineData("Ethan", "Alexander", "")]
    public void Create_InvalidName_ThrowArgumentException(string firstName, string? middleName, string lastName)
    {
        Assert.Throws<ArgumentException>(()  => Create(firstName, middleName, lastName));
    }

}
