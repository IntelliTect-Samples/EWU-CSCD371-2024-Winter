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
}
