using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test;

[TestClass]
public class SampleDataTests
{

    public SampleData SampleData { get; set; }

    public SampleDataTests()
    {
        SampleData = new();
    }

    [TestMethod]
    public void CsvRows_SkipsFirstLine_ReturnsSuccessful()
    {
        int CsvRows = SampleData.CsvRows.Count();
        Assert.AreEqual(50, CsvRows);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_SortedAndUnique_ReturnsSuccessful()
    {
        List<string> uniqueSortedStates = SampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        Assert.AreEqual("AL", uniqueSortedStates[0]);
        Assert.AreEqual("WV", uniqueSortedStates[26]);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardcodedList_ReturnsSuccessful()
    {
        string testList = "AL AZ CA DC FL GA IN KS LA MD MN MO MT NC NE NH NV NY OR PA SC TN TX UT VA WA WV";
        string correctList = string.Join(" ", SampleData.GetUniqueSortedListOfStatesGivenCsvRows());
        Assert.AreEqual(testList, correctList);

    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_SortedAndUnique_ReturnsSuccessful()
    {
        string uniqueSortedStates = string.Join(", ", SampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", uniqueSortedStates);
    }

    [TestMethod]
    public void People_CountIs50_ReturnsSuccessful()
    {
        var people = SampleData.People.ToList();

        Assert.AreEqual(50, people.Count);
    }

    // Filtered by .cn
    [TestMethod]
    public void FilterByEmailAddress_ContainsCn_ReturnsSuccessful()
    {
        List<(string FirstName, string LastName)> govEmails = SampleData.FilterByEmailAddress(email => email.Contains(".cn")).ToList();
        Assert.AreEqual(2, govEmails.Count);
    }

    // Filtered by .com
    [TestMethod]
    public void FilterByEmailAddress_ContainsCom_ReturnsSuccessful()
    {
        List<(string FirstName, string LastName)> comEmails = SampleData.FilterByEmailAddress(email => email.Contains(".com")).ToList();
        Assert.AreEqual(29, comEmails.Count);
    }

    // Filtered by .gov
    [TestMethod]
    public void FilterByEmailAddress_ContainsGov_ReturnsSuccessful()
    {
        List<(string FirstName, string LastName)> govEmails = SampleData.FilterByEmailAddress(email => email.Contains(".gov")).ToList();
        Assert.AreEqual(5, govEmails.Count);
    }

    // GetAggregateListOfStatesGivenPeopleCollection for Unique States
    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_UniqueList_ReturnsSuccessful()
    {
        List<IPerson> people = SampleData.People.ToList();
        string states = SampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
    }

    // GetAggregateListOfStatesGivenPeopleCollection with empty list
    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_EmptyList_ReturnsSuccessful()
    {
        List<IPerson> people = [];
        string states = SampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        Assert.AreEqual("", states);
    }

}