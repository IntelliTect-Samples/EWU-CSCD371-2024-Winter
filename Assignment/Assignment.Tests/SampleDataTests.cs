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
}
