using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private const string CsvFilePath = "People.csv";

        // 1.
        public IEnumerable<string> CsvRows 
            => File.ReadLines(CsvFilePath).Skip(1);// This should return the entire list, Line by Line, as a string
            
         // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows
                .Select(row => row.Split(',')[6])
                .Distinct()
                .OrderBy(state => state);//This will use CsvRows, calling in one large string,
                                         //splitting it at the 6th comma, and ordering by state
        
        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());//This should combine them,
                                                                           //though selecting only states I am unsure how to do 

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
