using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    //This is just here for now cuz idk how to write a good test for it yet..
    public void CsvRows_GetFirstRow_Success()
    {
        SampleData data = new();
        string firstLine = data.CsvRows.First();
        Assert.AreEqual<string>
            ("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", firstLine);
    }


    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedStates_Success()
    {
      // Create SampleData Object
      SampleData sampleData = new();
      // Create list of States that are in the Csv file (used excel to generate this)
      List<string> addresses = new List<string> {"AL", "AZ", "CA", "DC", "FL", "GA", "IN", 
        "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", 
        "TN", "TX", "UT", "VA", "WA", "WV"};

      // Create a result of when method executes
      var results = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

      // Take those addresses and use LINQ to make sure they are 
      // orderd correct (they already are since I used excel to get them)
      // Then make sure they are equivalent
      CollectionAssert.AreEquivalent(addresses
          .Distinct()
          .OrderBy(addr => addr, StringComparer.OrdinalIgnoreCase).ToList(), results.ToList());
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_InvokeMethod_Success()
    {
      // Grab list of addresses from before
      List<string> addresses = new List<string> {"AL", "AZ", "CA", "DC", "FL", "GA", "IN", 
        "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", 
        "TN", "TX", "UT", "VA", "WA", "WV"};
      // Join them all into a single string
      string hardList = string.Join(", ", addresses);

      SampleData sampleData = new();
      // Get single string of states from method
      string stateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
      // make sure string is populated
      Assert.IsNotNull(stateList);
      // make sure it is equal to hard coded string of states. 
      Assert.AreEqual(hardList, stateList);
    }

    [TestMethod]
    public void Persons_Creation_MatchesHardCodedPerson()
    {
      SampleData sampleData = new();

      var people = sampleData.People.ToList();

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
}
