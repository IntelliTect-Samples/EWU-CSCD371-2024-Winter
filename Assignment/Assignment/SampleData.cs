using System;
using System.Collections.Generic;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                // Specify the path to the People.csv file
                string csvFilePath = "People.csv";

                // Check if the file exists
                if (File.Exists(csvFilePath))
                {
                    // Read all lines from the file and return as enumerable
                    return File.ReadLines(csvFilePath);
                }
                else
                {
                    // If the file doesn't exist, throw an exception or handle it appropriately
                    throw new FileNotFoundException("People.csv file not found.");
                }
            }
        }
        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

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
