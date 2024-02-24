using System;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void ParseFile_SetsCorrectColumns()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        Assert.AreEqual<int>(TestingCsvData.DataColumns, sampleData.Columns);
    }

    [TestMethod]
    public void ParseFile_ThrowsIfNullOrEmpty()
    {
        Assert.ThrowsException<ArgumentException>(() =>
            SampleData.FromCsvString(""));
        Assert.ThrowsException<ArgumentNullException>(() =>
            SampleData.FromCsvString(null!));
    }

    [TestMethod]
    public void ParseFile_ThrowsExceptionIfInconsistentColumns()
    {
        Assert.ThrowsException<Exception>(() =>
            SampleData.FromCsvString(TestingCsvData.InconsistentColumnData));
    }

    [TestMethod]
    public void ParseFile_SkipsFirstRow()
    {
        SampleData sampleData = SampleData.FromCsvString(TestingCsvData.Data);
        string firstDataLine = sampleData.CsvRows.First();
        Assert.IsFalse(firstDataLine.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
    }
}