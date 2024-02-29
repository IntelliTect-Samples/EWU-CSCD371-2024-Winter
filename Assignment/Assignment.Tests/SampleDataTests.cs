using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{

    //Properties are set in SetUp method so they will not be null
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleData SampleData { get; set; }
    public string PeopleCSVPath { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void SetUp()
    {
        PeopleCSVPath = "people.csv";
        SampleData = new SampleData();
    }


    [TestMethod]
    public void CsvRows_PeopleCsv_ReturnsStringIEnumerable()
    {
        Assert.AreEqual<string>(File.ReadLines(PeopleCSVPath).Skip(1).First(), SampleData.CsvRows.First());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedAddreses_ReturnsDistinctSortedStateList()
    {

        List<string> distinctSortedStates = ["AL",
            "AZ",
            "CA",
            "DC",
            "FL",
            "GA",
            "IN",
            "KS",
            "LA",
            "MD",
            "MN",
            "MO",
            "MT",
            "NC",
            "NE",
            "NH",
            "NV",
            "NY",
            "OR",
            "PA",
            "SC",
            "TN",
            "TX",
            "UT",
            "VA",
            "WA",
            "WV"];

        Assert.AreEqual(distinctSortedStates.Count,SampleData.GetUniqueSortedListOfStatesGivenCsvRows().Zip(distinctSortedStates, (csvRow, hardCodeState) => csvRow == hardCodeState).Count());

    }
}

