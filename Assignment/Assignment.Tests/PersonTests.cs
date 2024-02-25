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
        Assert.AreEqual(firstName, expectedRowPerson.FirstName);
        Assert.AreEqual(lastName, expectedRowPerson.LastName);
        Assert.AreEqual(email, expectedRowPerson.EmailAddress);
        Assert.AreEqual(streetAddress, expectedRowPerson.Address.StreetAddress);
        Assert.AreEqual(city, expectedRowPerson.Address.City);
        Assert.AreEqual(state, expectedRowPerson.Address.State);
        Assert.AreEqual(zipCode, expectedRowPerson.Address.Zip);
    }
}
