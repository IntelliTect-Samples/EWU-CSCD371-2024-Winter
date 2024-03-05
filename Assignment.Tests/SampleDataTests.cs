using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{

    //Properties are set in SetUp method so they will not be null
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleData SampleData { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void SetUp()
    {
        SampleData = new SampleData();
    }


    [TestMethod]
    public void CsvRows_PeopleCsv_ReturnsStringIEnumerable()
    {
        Assert.IsTrue(File.ReadLines("people.csv").Skip(1).SequenceEqual(SampleData.CsvRows.ToArray()));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_UsingHardCodedAddresses_ReturnsDistinctSortedStateList()
    {

        List<string> distinctSortedStates = ["AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"];

        Assert.AreEqual(distinctSortedStates.Count, SampleData.GetUniqueSortedListOfStatesGivenCsvRows().Zip(distinctSortedStates, (csvRow, hardCodeState) => csvRow == hardCodeState).Count());

    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_UsingLINQ_ReturnsDistinctSortedStateList()
    {
        Assert.IsTrue(new HashSet<string>(SampleData.CsvRows.Select(row => row.Split(',')[6]).OrderBy(state => state)).SequenceEqual(SampleData.GetUniqueSortedListOfStatesGivenCsvRows()));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_NonEmptyCsvRows_ReturnsSortedStringList()
    {
        string uniqueStatesList = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";

        Assert.AreEqual<string>(uniqueStatesList, SampleData.GetAggregateSortedListOfStatesUsingCsvRows());
    }

    [TestMethod]
    public void PeopleProperty_PeopleCSV_ReturnsSortedListOfPeople()
    {
        IEnumerable<string> persons = SampleData.CsvRows
            .Select(line => line.Split(","))
            .OrderBy(line => line[5])
            .ThenBy(line => line[6])
            .ThenBy(line => line[7])
            .Select(line => line[1..])
            .Select(line => string.Join(",", line));

        IEnumerable<string> peopleProperty = SampleData.People
            .Select(person => 
            $"{person.FirstName},{person.LastName},{person.EmailAddress},{person.Address.StreetAddress},{person.Address.City},{person.Address.State},{person.Address.Zip}");


        Assert.IsTrue(persons.SequenceEqual(peopleProperty));

    }

    [TestMethod]
    public void FilterByEmailAddress_FilterByEducationEmail_ReturnsIEnumerablePeopleWithEduEmails()
    {

        // Arrange, Act, and Assert 
        Assert.IsTrue(new List<(string, string)> { ("Claudell", "Leathe"), ("Fayette", "Dougherty"), ("Fremont", "Pallaske"), ("Issiah", "Bester"), ("Sancho", "Mahony")}.SequenceEqual(SampleData.FilterByEmailAddress((email) => email.Contains(".edu")).OrderBy(fullName => fullName.FirstName)));
        
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ValidPersonCollection_ReturnsUniqueStatesList()
    {

        Assert.AreEqual(SampleData.GetAggregateSortedListOfStatesUsingCsvRows(), string.Join(", ", SampleData.GetAggregateListOfStatesGivenPeopleCollection(SampleData.People).Split(", ").OrderBy(state => state).ToList()));
    }
}

