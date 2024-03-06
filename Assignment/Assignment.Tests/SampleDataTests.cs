using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    //Will not be null because property is setup in SetupSampleData
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleData SampleData {  get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void SetupSampleData()
    {
        SampleData = new SampleData();
    }

    [TestMethod]
    public void CsvRows_GetFirstRow_Success()
    {
        string firstLine = SampleData.CsvRows.First();
        Assert.AreEqual<string>
            ("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", firstLine);
    }

    [TestMethod]
    public void CsvRows_CountMatches_Success()
    {
        Assert.AreEqual<int>(50, SampleData.CsvRows.Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedStates_Success()
    {
      // Create list of States that are in the Csv file (used excel to generate this)
      List<string> addresses = ["AL", "AZ", "CA", "DC", "FL", "GA", "IN", 
        "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", 
        "TN", "TX", "UT", "VA", "WA", "WV"];

      // Create a result of when method executes
      var results = SampleData.GetUniqueSortedListOfStatesGivenCsvRows();

      // Take those addresses and use LINQ to make sure they are 
      // orderd correct (they already are since I used excel to get them)
      // Then make sure they are equivalent
      CollectionAssert.AreEquivalent(addresses
          .Distinct()
          .OrderBy(addr => addr, StringComparer.OrdinalIgnoreCase).ToList(), results.ToList());
    }
    
    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_LinqTest_Success()
    {
      //Arrange
      var sampleData = new SampleData();
      var expectedSortedStates = sampleData.CsvRows
          .Select(row => row.Split(',')[6].Trim())
          .Distinct()
          .OrderBy(state => state, StringComparer.OrdinalIgnoreCase)
          .ToList();

      //Act
      var actualSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

      //Assert
      CollectionAssert.AreEqual(expectedSortedStates, actualSortedStates);
    }


    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_InvokeMethod_Success()
    {
      // Grab list of addresses from before
      List<string> addresses = ["AL", "AZ", "CA", "DC", "FL", "GA", "IN", 
        "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", 
        "TN", "TX", "UT", "VA", "WA", "WV"];
      // Join them all into a single string
      string hardList = string.Join(", ", addresses);

      // Get single string of states from method
      string stateList = SampleData.GetAggregateSortedListOfStatesUsingCsvRows();
      // make sure string is populated
      Assert.IsNotNull(stateList);
      // make sure it is equal to hard coded string of states. 
      Assert.AreEqual(hardList, stateList);
    }

    [TestMethod]
    public void Persons_Creation_MatchesHardCodedPerson()
    {
      var people = SampleData.People.ToList();

      Assert.AreEqual(50, people.Count);

      // Since we sort by state first, Arthur will be first since 
      // AL is the first State alphebetically
      Assert.AreEqual("Arthur", people[0].FirstName);
      Assert.AreEqual("Myles", people[0].LastName);
      Assert.AreEqual("amyles1c@miibeian.gov.cn", people[0].EmailAddress);
      Assert.AreEqual("4718 Thackeray Pass", people[0].Address.StreetAddress);
      Assert.AreEqual("Mobile", people[0].Address.City);
      Assert.AreEqual("AL", people[0].Address.State);
      Assert.AreEqual("37308", people[0].Address.Zip);
    }

    [TestMethod]
    public void FilterByEmailAddress_FilterUsesEquals_Success()
    {
        //An example of what the filter could be
        Predicate<string> filter = s => s.Equals("ibester6@psu.edu");

        //The tuple list of names to be returned
        var names = SampleData.FilterByEmailAddress(filter);

        //Since emails are unique in this list, should be only one result
        Assert.AreEqual(1, names.Count());
        Assert.AreEqual(("Issiah", "Bester"), names.Single());
        
    }

    [TestMethod]
    public void FilterByEmailAddress_FilterUsesContains_Success()
    {
        //An example of what the filter could be
        Predicate<string> filter = s => s.Contains(".gov");

        //The tuple list of names to be returned
        var names = SampleData.FilterByEmailAddress(filter);

        //Since emails are unique in this list, should be only one result
        Assert.AreEqual(5, names.Count());

        //These are the only five with .gov
        Assert.IsTrue(names.Contains(("Priscilla", "Jenyns")));
        Assert.IsTrue(names.Contains(("Amelia", "Toal")));
        Assert.IsTrue(names.Contains(("Ev", "Challace")));
        Assert.IsTrue(names.Contains(("Marijn", "McKennan")));
        Assert.IsTrue(names.Contains(("Arthur", "Myles")));

        //Issiah does not have a .gov email
        Assert.IsFalse(names.Contains(("Issiah", "Bester")));
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_GenerateList_MatchesGetUniqueSortedListOfStatesGivenCsvRows()
    {
        //Use GetUniqueSortedListOfStatesGivenCsvRows to form the list we need.
        //Use the Join function o string to turn that list into a string.
        string expected = string.Join(", ", SampleData.GetUniqueSortedListOfStatesGivenCsvRows());

        //The string returned should match the one that used method above.
        string result = SampleData.GetAggregateListOfStatesGivenPeopleCollection(SampleData.People);

        Assert.AreEqual(expected, result);
    }
}
