using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        Assert.Equals(firstName, person.FirstName);
        Assert.Equals(lastName, person.LastName);
        Assert.Equals(address, person.Address);
        Assert.Equals(emailAddress, person.EmailAddress);
    }

    [Fact]
    public void FirstName_CanBeSetAndRetrieved()
    {
        // Arrange
        var person = new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com");

        // Act
        person.FirstName = "Jane";

        // Assert
        Assert.Equals("Jane", person.FirstName);
    }

    [Fact]
    public void LastName_CanBeSetAndRetrieved()
    {
        // Arrange
        var person = new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com")
        {
            // Act
            LastName = "Smith"
        };

        // Assert
        Assert.Equals("Smith", person.LastName);
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
        Assert.Equals(address, person.Address);
    }

    [Fact]
    public void EmailAddress_CanBeSetAndRetrieved()
    {
        // Arrange
        var person = new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com");

        // Act
        person.EmailAddress = "jane@example.com";

        // Assert
        Assert.Equals("jane@example.com", person.EmailAddress);
    }
}