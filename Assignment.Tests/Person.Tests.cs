using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Assignment.Tests;
public class PersonTests
{
    [TestMethod]
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
        Assert.AreEqual(firstName, person.FirstName);
        Assert.AreEqual(lastName, person.LastName);
        Assert.AreEqual(address, person.Address);
        Assert.AreEqual(emailAddress, person.EmailAddress);
    }

    [TestMethod]
    public void FirstName_CanBeSetAndRetrieved()
    {
        // Arrange
        Person person = new("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com")
        {
            // Act
            FirstName = "Jane"
        };

        // Assert
        Assert.AreEqual("Jane", person.FirstName);
    }

    [TestMethod]
    public void LastName_CanBeSetAndRetrieved()
    {
        // Arrange
        Person person = new("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com")
        {
            // Act
            LastName = "Smith"
        };

        // Assert
        Assert.AreEqual("Smith", person.LastName);
    }

    [TestMethod]
    public void Address_CanBeSetAndRetrieved()
    {
        // Arrange
        Address address = new("456 Elm St", "Other City", "NY", "67890");
        Person person = new("John", "Doe", address, "john@example.com")
        {
            // Act
            Address = address
        };

        // Assert
        Assert.AreEqual(address, person.Address);
    }

    [TestMethod]
    public void EmailAddress_CanBeSetAndRetrieved()
    {
        // Arrange
        Person person = new("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com")
        {
            // Act
            EmailAddress = "jane@example.com"
        };

        // Assert
        Assert.AreEqual("jane@example.com", person.EmailAddress);
    }
}