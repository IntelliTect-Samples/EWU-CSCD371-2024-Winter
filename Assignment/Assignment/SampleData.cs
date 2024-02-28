using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private const string FILEPATH = "People.csv";
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                using (StreamReader streamReader = new StreamReader(FILEPATH))
                {
                    streamReader.ReadLine();

                    while(streamReader.EndOfStream)
                    {
                        yield return streamReader.ReadLine()!;
                    }
                }
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            var states = CsvRows.Select(row =>
            {
                // Parse state from each row
                var state = row.Split(',')[2]; // Assuming state is at index 2
                return state.Trim(); // Trim any leading/trailing spaces
            }).Distinct(); // Ensure uniqueness

            return states.OrderBy(state => state); // Sort alphabetically
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            var statesArray = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            return string.Join(",", statesArray);
        }

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
