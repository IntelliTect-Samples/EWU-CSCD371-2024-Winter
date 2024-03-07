
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{

    
    #pragma warning disable CS8618 
    public SampleData SampleData { get; set; }
    #pragma warning restore CS8618 
    //Non-nullable property 'SampleData' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

    [TestInitialize]
    public void Init(){ SampleData = new SampleData(); }


    [TestMethod]
    public void CsvRows_PeopleCsv_MatchesExpectedFormat()
    {
        
        int expectedColumnCount = 8; 

        // Read all lines from the file
        var csvRowsFromFile = File.ReadLines("People.csv").Skip(1);

        // Get the CSV rows from SampleData object
        var csvRowsFromSampleData = SampleData.CsvRows;

        // Check if the number of columns in each CSV row matches the expected count
        foreach (var row in csvRowsFromSampleData)
        {
            var columns = row.Split(',');
            Assert.AreEqual(expectedColumnCount, columns.Length, $"Incorrect number of columns in CSV row: {row}");
        }

        // Check if the CSV rows from the file match the ones from SampleData
        Assert.IsTrue(csvRowsFromFile.SequenceEqual(csvRowsFromSampleData));
        }


    [TestMethod]
    public void People_PeopleCSV_ReturnsSortedListOfPeople()
    {
        // Convert CSV rows into formatted strings representing people's data
        IEnumerable<string> personsFromCsv = SampleData.CsvRows
            .Select(line => line.Split(","))
            .OrderBy(line => (line[5], line[6], line[7]))
            .Select(line => string.Join(",", line.Skip(1)));

        // Convert people objects into formatted strings representing people's data
        IEnumerable<string> personsFromObjects = SampleData.People
            .Select(person =>
                $"{person.FirstName},{person.LastName},{person.EmailAddress},{person.Address.StreetAddress},{person.Address.City},{person.Address.State},{person.Address.Zip}");

        // Assert that both sequences of formatted strings are equal
        Assert.IsTrue(personsFromCsv.SequenceEqual(personsFromObjects));
    }


    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_LINQ_ReturnsDistinctSortedStateList()
    {
        // Get the list of states from SampleData method
        var statesFromSampleData = SampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Get the list of states directly from the CSV rows, split them, and select the state
        var statesFromCsv = SampleData.CsvRows
            .Select(row => row.Split(',')[6].Trim()) // Extract and trim the state from each CSV row
            .OrderBy(state => state) // Sort the states
            .Distinct(); // Get the distinct states

        // Assert that both lists contain the same elements
        CollectionAssert.AreEqual(statesFromCsv.ToList(), statesFromSampleData.ToList());
    }



    [TestMethod]
    public void FilterByEmailAddress_FilterByEducationEmail_ReturnsPeopleWithGovEmails()
    {

        Assert.IsTrue(new List<(string, string)> { ("Amelia" , "Toal"), ("Arthur" ,"Myles"), ("Ev", "Challace"), ("Marijn", "McKennan"), ("Priscilla", "Jenyns") }.SequenceEqual(SampleData.FilterByEmailAddress((email) => email.Contains(".gov")).OrderBy(fullName => fullName.FirstName)));

    }



    
}


    



    
