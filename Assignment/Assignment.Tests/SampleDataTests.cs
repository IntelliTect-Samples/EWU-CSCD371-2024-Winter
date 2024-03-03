using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Assignment.Tests;

public class SampleDataTests
{
    public SampleData SampleData { get; set; }

    public SampleDataTests() 
    {
        SampleData = new();
    }

    [Fact]
    public void CsvRows_SkipsFirstLine_ReturnsSuccessful()
    {
        int CsvRows = SampleData.CsvRows.Count();
        Assert.Equal(50, CsvRows);
    }

    [Fact]
    public void GetUniqueSortedListOfStatesGivenCsvRows_SortedAndUnique_ReturnsSuccessful()
    {
        List<string> uniqueSortedStates = SampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        Assert.Equal("AL", uniqueSortedStates[0]);
        Assert.Equal("WV", uniqueSortedStates[26]);
    }
    /* needs fixing commented out for testing other tests
        [Fact]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ListIsJoinedProperly_ReturnsSuccessfully()
        {
            List<string> uniqueSortedStates = ["AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", 
                "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"];
            Assert.Equal(uniqueSortedStates.Count, SampleData.GetAggregateSortedListOfStatesUsingCsvRows().Count());
        } */

    //Need test for people
}