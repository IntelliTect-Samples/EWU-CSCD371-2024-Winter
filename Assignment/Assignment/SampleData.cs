using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    // Read all lines from the file and return as enumerable, skipping the first row
                    return File.ReadLines(csvFilePath).Skip(1);
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
        {
            // Read CSV rows from CsvRows property
            var csvRows = CsvRows;

            // Extract states and remove duplicates
            var stateSet = new HashSet<string>();
            foreach (var row in csvRows)
            {
                var columns = row.Split(',');
                if (columns.Length >= 7) // Assuming state is at index 6
                {
                    stateSet.Add(columns[6].Trim()); // Trim to remove any extra spaces
                }
            }

            // Convert to a list and sort alphabetically
            var sortedStates = new List<string>(stateSet);
            sortedStates.Sort(StringComparer.OrdinalIgnoreCase); // Case-insensitive sorting

            return sortedStates;
        }

        //2 OVEROAD FOR TESTING
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows(IEnumerable<string>? addresses = null)
        {
            IEnumerable<string> csvRows;

            if (addresses == null)
            {
                csvRows = CsvRows;
            }
            else
            {
                csvRows = addresses;
            }

            var stateSet = new HashSet<string>();
            foreach (var row in csvRows)
            {
                var columns = row.Split(',');
                if (columns.Length >= 7)
                {
                    stateSet.Add(columns[6].Trim());
                }
            }

            var sortedStates = stateSet.OrderBy(s => s, StringComparer.OrdinalIgnoreCase);

            return sortedStates;
        }
        

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            // Get unique, sorted list of states
            var uniqueSortedStates = GetUniqueSortedListOfStatesGivenCsvRows();

            // Select only the state names and convert to array
            var stateNamesArray = uniqueSortedStates.Select(state => state.Split(',')[6].Trim()).ToArray();

            // Convert array of state names into a comma-separated string
            string aggregatedStates = string.Join(",", stateNamesArray);

            return aggregatedStates;
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
