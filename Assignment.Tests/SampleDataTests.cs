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
    public void CsvRows_SkipsFirstLine_ReturnsSuccessful()//
    {
        int CsvRows = SampleData.CsvRows.Count();
        Assert.Equal(50, CsvRows);
    }
    /*
    [Fact]
    public void GetUniqueSortedListOfStatesGivenCsvRows_SortedAndUnique_ReturnsSuccessful()
    {
        List<string> uniqueSortedStates = SampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        Assert.Equal("AL", uniqueSortedStates[0]);
        Assert.Equal("WV", uniqueSortedStates[26]);
    }*/
    
    [Fact]
    public void GetAggregateSortedListOfStatesUsingCsvRows_SortedAndUnique_ReturnsSuccessful()
    {
        string uniqueSortedStates = string.Join(", ", SampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        Assert.Equal("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", uniqueSortedStates);
    }

    [Fact]
    public void People_CountIs50_ReturnsSuccessful()//
    {
        var people = SampleData.People.ToList();

        Assert.Equal(50, people.Count);
    }
    /*
    // Filtered by .cn
    [Fact]
    public void FilterByEmailAddress_ContainsCn_ReturnsSuccessful()
    {
        List<(string FirstName, string LastName)> govEmails = SampleData.FilterByEmailAddress(email => email.Contains(".cn")).ToList();
        Assert.Equal(2, govEmails.Count);
    }
    */
    // Filtered by .com
    [Fact]
    public void FilterByEmailAddress_ContainsCom_ReturnsSuccessful()//
    {
        List<(string FirstName, string LastName)> comEmails = SampleData.FilterByEmailAddress(email => email.Contains(".com")).ToList();
        Assert.Equal(29, comEmails.Count);
    }

    // Filtered by .gov
    [Fact]
    public void FilterByEmailAddress_ContainsGov_ReturnsSuccessful()//
    {
        List<(string FirstName, string LastName)> govEmails = SampleData.FilterByEmailAddress(email => email.Contains(".gov")).ToList();
        Assert.Equal(5, govEmails.Count);
    }
    /*
    // GetAggregateListOfStatesGivenPeopleCollection for Unique States
    [Fact]
    public void GetAggregateListOfStatesGivenPeopleCollection_UniqueList_ReturnsSuccessful()
    {
        List<IPerson> people = SampleData.People.ToList();
        string states = SampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.Equal("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
    }

    // GetAggregateListOfStatesGivenPeopleCollection with empty list
    [Fact]
    public void GetAggregateListOfStatesGivenPeopleCollection_EmptyList_ReturnsSuccessful()
    {
        List<IPerson> people = [];
        string states = SampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.Equal("", states);
    }
    */

}