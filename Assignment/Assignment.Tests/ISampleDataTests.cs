using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    }
}

