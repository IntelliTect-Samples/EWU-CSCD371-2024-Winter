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
        Assert.ThrowsException<Exception>(() =>
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
}