using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void FromCsvString_SetsCorrectColumns()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        Assert.AreEqual<int>(TestingCsvData.DataColumns, sampleData.Columns);
    }

    [TestMethod]
    public void FromCsvString_ThrowsIfNullOrEmpty()
    {
        Assert.ThrowsException<ArgumentException>(() =>
            SampleData.FromCsvString(""));
        Assert.ThrowsException<ArgumentNullException>(() =>
            SampleData.FromCsvString(null!));
    }

    [TestMethod]
    public void FromCsvString_ThrowsExceptionIfInconsistentColumns()
    {
        Assert.ThrowsException<ArgumentException>(() =>
            SampleData.FromCsvString(TestingCsvData.InconsistentColumnData));
    }

    [TestMethod]
    public void FromCsvString_SkipsFirstRow()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        string firstDataLine = sampleData.CsvRows.First();
        Assert.IsFalse(firstDataLine.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
    }

    [TestMethod]
    public void People_ReturnsCorrectCount()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        int count = sampleData.People.Count();
        Assert.AreEqual(50, count);
        (string firstName, string lastName, string email, string streetAddress, string city,
            string state, string zipCode) = (Person)sampleData.People.First();
        Assert.AreEqual("Arthur", firstName);
        Assert.AreEqual("Myles", lastName);
        Assert.AreEqual("amyles1c@miibeian.gov.cn", email);
        Assert.AreEqual("4718 Thackeray Pass", streetAddress);
        Assert.AreEqual("Mobile", city);
        Assert.AreEqual("AL", state);
        Assert.AreEqual("37308", zipCode);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_GivesUniqueStateRows()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        foreach (string state in states)
        {
            Assert.AreEqual(1, states.Where((s) => s == state).Count());
        }
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_GivesAggregateSortedStates()
    {
        string expected = TestingCsvData.UniqueStates;
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsCorrectData_Hardcoded()
    {
        List<string> states = SampleData.FromCsvString(@"Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
1,B,B,B,B,B,B,B
2,B,B,B,B,B,B,B
3,A,A,A,A,A,A,A
4,a,a,a,a,a,a,a").GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        string[] expectedStates = ["a", "A", "B"];
        for (int i = 0; i < states.Count; i++)
        {
            Assert.AreEqual(expectedStates[i], states[i]);
        }
    }
    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsCorrectData_LINQ()
    {
        List<string> states = SampleData.FromCsvString(@"Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
1,B,B,B,B,B,B,B
2,B,B,B,B,B,B,B
3,C,C,C,C,C,C,C
4,A,A,A,A,A,A,A
5,A,A,A,A,A,A,A
6,a,a,a,a,a,a,a
7,a,a,a,a,a,a,a").GetUniqueSortedListOfStatesGivenCsvRows().ToList();

        List<string> states2 = [.. (from state in states orderby state ascending select state)];

        for (int i = 0; i < states.Count; i++)
        {
            Assert.AreEqual(states2[i], states[i]);
        }
    }

    [TestMethod]
    public void FilterByEmailAddress_SetFilterToNull_ThrowArgumentNullException()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        Assert.ThrowsException<ArgumentNullException>(
            () => sampleData.FilterByEmailAddress(null!));
    }

    [TestMethod]
    public void FilterByEmailAddress_SetFilterToSpecificEmail_Ture()
    {
        // sdennington9@chron.com an email of 10'th person in People.csv. First = Scarface, Last = Dennington
        (string firstName, string lastName) expected = ("Scarface", "Dennington");
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        Predicate<string> filter = email => email == "sdennington9@chron.com";
        IEnumerable<(string firstName, string lastName)> actual = sampleData.FilterByEmailAddress(filter);
        Assert.AreEqual(expected, actual.First());
    }

    [TestMethod]
    public void FilterByEmailAddress_ReturnDuplicateEmail_True()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.DataDuplicateEmail);
        Predicate<string> filter = email => email == "cstennine2@wired.com";
        IEnumerable<(string firstName, string lastName)> actual = sampleData.FilterByEmailAddress(filter);

        Assert.AreEqual(3, actual.Count());
    }

    [TestMethod]
    [DataRow(TestingCsvData.Data)]
    [DataRow(TestingCsvData.DataDuplicateEmail)]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsSameAs_GetUniqueSortedListOfStatesGivenCsvRows(string csvSource)
    {
        SampleData sampleData = SampleData.FromCsvString(csvSource);
        string aggregateWithPeople = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
        string aggregateUsingCsvRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        Assert.AreEqual(aggregateWithPeople, aggregateUsingCsvRows);
    }
}