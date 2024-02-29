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
        // Arrange
        IEnumerable<string> peopleCSV = SampleData.CsvRows;
        using StreamReader writer = new(PeopleCSVPath);

        // Act
        writer.ReadLine();
        string? firstRow = writer.ReadLine();

        // Assert
        Assert.Equals(peopleCSV.First(), firstRow);
    }
}

