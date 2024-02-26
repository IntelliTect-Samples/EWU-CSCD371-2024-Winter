using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment;
using Xunit;
namespace Assignment.Tests;
public class PersonTests
{
    [Fact]
    public void Constructor_Initializes_Person_Object()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        IAddress address = new Address("123 Main St", "Anytown", "CA", "12345");
        string emailAddress = "john@example.com";

        // Act
        var person = new Person(firstName, lastName, address, emailAddress);

        // Assert
        Assert.Equal(firstName, person.FirstName);
        Assert.Equal(lastName, person.LastName);
        Assert.Equal(address, person.Address);
        Assert.Equal(emailAddress, person.EmailAddress);
    }

    [Fact]
    public void FirstName_CanBeSetAndRetrieved()
    {
        // Arrange
        var person = new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com");

        // Act
        person.FirstName = "Jane";

        // Assert
        Assert.Equal("Jane", person.FirstName);
    }

    [Fact]
    public void LastName_CanBeSetAndRetrieved()
    {
        // Arrange
        var person = new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com");

        // Act
        person.LastName = "Smith";

        // Assert
        Assert.Equal("Smith", person.LastName);
    }

    [Fact]
    public void Address_CanBeSetAndRetrieved()
    {
        // Arrange
        var address = new Address("456 Elm St", "Other City", "NY", "67890");
        var person = new Person("John", "Doe", address, "john@example.com");

        // Act
        person.Address = address;

        // Assert
        Assert.Equal(address, person.Address);
    }

    [Fact]
    public void EmailAddress_CanBeSetAndRetrieved()
    {
        // Arrange
        var person = new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com");

        // Act
        person.EmailAddress = "jane@example.com";

        // Assert
        Assert.Equal("jane@example.com", person.EmailAddress);
    }
}