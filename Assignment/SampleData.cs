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

                    while (streamReader.EndOfStream)
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
        public IEnumerable<IPerson> People
        {
            get
            {
                // Parse each CSV row into Person objects
                var people = CsvRows.Skip(1).Select(row =>
                {
                    var columns = row.Split(',');
                    var address = new Address(columns[0], columns[1], columns[2], columns[3]);
                    return new Person(columns[4], columns[5], address, columns[6]);
                });

                // Sort by State, City, and Zip
                return people.OrderBy(person => person.Address.State)
                             .ThenBy(person => person.Address.City)
                             .ThenBy(person => person.Address.Zip);
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress))
                .Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            var states = people.Select(person => person.Address.State)
                .Distinct()
                .OrderBy(state => state);
            return string.Join(",", states);
        }
    }
}
