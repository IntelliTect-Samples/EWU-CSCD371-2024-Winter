using System;

namespace Assignment.Tests;

[TestClass]
public class PersonTests
{
    [TestMethod]
    public void FromCsvRow_ThrowsArgumentExceptionOnNullOrEmpty()
    {
        Assert.ThrowsException<ArgumentException>(() => Person.FromCsvRow(""));
        Assert.ThrowsException<ArgumentNullException>(() => Person.FromCsvRow(null!));
    }

    [TestMethod]
    public void FromCsvRow_ThrowsExceptionIfNotEnoughColumns()
    {
        string badRow = "one,two,three,four,five,six,seven,eight,nine";
        string goodRow = "one,two,three,four,five,six,seven,eight";
        Assert.ThrowsException<Exception>(() => Person.FromCsvRow(badRow));
        Assert.IsNotNull(Person.FromCsvRow(goodRow));
    }

    [TestMethod]
    public void FromCsvRow_AssignsCorrectValues()
    {
        string row = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        Person expectedRowPerson = new("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0@state.gov");
        Person rowPerson = Person.FromCsvRow(row);
        (string firstName, string lastName, string email, string streetAddress, string city,
            string state, string zipCode) = rowPerson;
        Assert.AreEqual(expectedRowPerson.FirstName, firstName);
        Assert.AreEqual(expectedRowPerson.LastName, lastName);
        Assert.AreEqual(expectedRowPerson.EmailAddress, email);
        Assert.AreEqual(expectedRowPerson.Address.StreetAddress, streetAddress);
        Assert.AreEqual(expectedRowPerson.Address.City, city);
        Assert.AreEqual(expectedRowPerson.Address.State, state);
        Assert.AreEqual(expectedRowPerson.Address.Zip, zipCode);
    }

    [TestMethod]
    public void ToCsvRow_NoComma_ReturnsCorrectData()
    {
        Person personNoComma = new("First", "Last", new Address("Street", "City", "State", "Zip"), "Email");
        string row = personNoComma.ToCsvRow();
        string expectedRow = "First,Last,Email,Street,City,State,Zip";
        Assert.AreEqual(expectedRow, row);
    }

    [TestMethod]
    public void ToCsvRow_WithComma_ReturnsCorrectData()
    {
        Person personNoComma = new("F,irst", "Last", new Address("Street", "City", "State", "Zip"), "Email");
        string row = personNoComma.ToCsvRow();
        string expectedRow = "\"F,irst\",Last,Email,Street,City,State,Zip";
        Assert.AreEqual(expectedRow, row);
    }
}
