using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    //I tried my best with these but only 1 is currently passing haha
    private const string TestCsvFilePath = "People.csv"; // Makes a testing file with sample data
    SampleData sampleData = new();

    [TestInitialize]
    public void Initialize()
    {
        // Sample Data added to the test file
        var testCsvContent = "FirstName,LastName,StreetAddress,City,State,Zip,EmailAddress\n" +
                             "John,Doe,123 Main St,Anytown,CA,12345,john@example.com\n" +
                             "Jane,Smith,456 Elm St,Other City,NY,67890,jane@example.com";
        File.WriteAllText(TestCsvFilePath, testCsvContent);
        
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Delete the test CSV file
        if (File.Exists(TestCsvFilePath))
            File.Delete(TestCsvFilePath);
    }

    [TestMethod]
    public void CsvRows_SkipsFirstRow_ReturnsAllRowsFromFile()
    {

        var result = sampleData.CsvRows.ToList();

        Assert.AreEqual(2, result.Count);
        CollectionAssert.Contains(result, "John,Doe,123 Main St,Anytown,CA,12345,john@example.com");
        CollectionAssert.Contains(result, "Jane,Smith,456 Elm St,Other City,NY,67890,jane@example.com");
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedEmails()
    {

        var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("CA", result[0]);
        Assert.AreEqual("NY", result[1]);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateSortedStates()
    {


        var result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        Assert.AreEqual("CA,NY", result);
    }

    [TestMethod]
    public void People_ReturnsListOfPeople()
    {


        var result = sampleData.People.ToList();

        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.Any(p => p.FirstName == "John" && p.LastName == "Doe"));
        Assert.IsTrue(result.Any(p => p.FirstName == "Jane" && p.LastName == "Smith"));
    }

    [TestMethod]
    public void FilterByEmailAddress_ReturnsFilteredPeople()
    {


        static bool filter(string email) => email.EndsWith("@example.com", StringComparison.OrdinalIgnoreCase);

        var result = sampleData.FilterByEmailAddress(filter).ToList();

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(("John", "Doe"), result[0]);
        Assert.AreEqual(("Jane", "Smith"), result[1]);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsAggregateListOfStates()
    {

        List<IPerson> people =
            [
                new Person("John", "Doe", new Address("123 Main St", "Anytown", "CA", "12345"), "john@example.com"),
                new Person("Jane", "Smith", new Address("456 Elm St", "Other City", "NY", "67890"), "jane@example.com")
            ];

        var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        Assert.AreEqual("CA,NY", result);
    }
}

