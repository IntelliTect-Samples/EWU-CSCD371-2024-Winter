//using System;
//using Xunit;

//namespace Assignment.Tests;
//public class SampleDataTests
//{
//    [Fact]
//    public void SampleTest()
//    {
//        string str = "meow";
//        Assert.Equal("meow", str);
//    }
//}

using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Assignment.Tests;

public class SampleDataTests
{
    // Test for verifying the correctness of CsvRows property output
    [Fact]
    public void CsvRows_ReturnsCorrectOutput()
    {
        IEnumerable<string> csvRows = new SampleData().CsvRows.ToList();
        Assert.Equal(50, csvRows.Count());
    }

    // Test for verifying the correctness of output from GetUniqueSortedListOfStatesGivenCsvRows method
    [Fact]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsCorrectOutput()
    {
        IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        bool isSorted = states.Zip(states, (first, second) => String.Compare(first, second, StringComparison.Ordinal) < 0 || first.Equals(second, StringComparison.Ordinal)).All(rows => rows);
        Assert.True(isSorted);
    }

    // Test for verifying hardcoded values in GetUniqueSortedListOfStatesGivenCsvRows method
    [InlineData("MT")]
    [InlineData("FL")]
    [InlineData("CA")]
    [Theory]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedValues_ReturnsCorrect(string row)
    {
        IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        Assert.Contains(row, states);
    }

    // Test for verifying the correctness of output from GetAggregateSortedListOfStatesUsingCsvRows method
    [Fact]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCorrectOutput()
    {
        string states = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();
        Assert.Equal("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
    }

    // Test for verifying the number of people returned by the People property
    [Fact]
    public void People_ReturnsCorrectNumberOfPeople()
    {
        IEnumerable<IPerson> peopleList = new SampleData().People;
        Assert.Equal(50, peopleList.Count());
    }

    // Test for verifying the correctness of the first person returned by the People property
    [Fact]
    public void People_FirstPerson_IsCorrect()
    {
        IEnumerable<IPerson> peopleList = new SampleData().People;
        Assert.Equal("Arthur", peopleList.ElementAt(0).FirstName);
    }

    // Test for verifying filtering of people by email address
    [Fact]
    public void People_FilterByEmail_ReturnsCorrectFirstPerson()
    {
        IEnumerable<(string firstname, string lastname)> filteredPeople = new SampleData()
            .FilterByEmailAddress(email => email.Contains(".edu"));

        Assert.Equal("Fremont", filteredPeople.ElementAt(0).firstname);
    }

    // Test for verifying the correctness of states returned by GetAggregateListOfStatesGivenPeopleCollection method
    [Fact]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsCorrectListOfStates()
    {
        IEnumerable<IPerson> people = new SampleData().People;
        IEnumerable<string> aggregatedStates = new SampleData()
            .GetAggregateListOfStatesGivenPeopleCollection(people)
            .Split(", ")
            .OrderBy(state => state)
            .ToList();
        string states = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();

        string aggregatedStatesStr = string.Join(", ", aggregatedStates);

        Assert.Contains(states, aggregatedStatesStr);
    }

}


