
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment.Interfaces;

namespace Assignment;

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
    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        var uniqueStates = GetUniqueSortedListOfStatesGivenCsvRows();
        return string.Join(", ", uniqueStates);
    }

    // 4.
    public IEnumerable<IPerson> People => CsvRows
    .Select(line => line.Split(","))
    .Select(columns => new
    {
        Line = columns,
        Address = new Address(columns[4], columns[5], columns[6], columns[7]),
        Person = new Person(columns[1], columns[2], null!, columns[3]) // Address will be set below
    })
    .OrderBy(item => (item.Line[5], item.Line[6], item.Line[7]))
    .Select(item =>
    {
        item.Person.Address = item.Address;
        return item.Person;
    });

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) {
            //searching the people list for matching filter predicate, then selecting the tuple firstname, lastname and returning it
            
            IEnumerable<(string Fn, string Ln)> matches = People
                .Where(currentPerson => filter(currentPerson.EmailAddress))
                .Select(personFullName => (personFullName.FirstName, personFullName.LastName));
            return matches;
        }
        
    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        { 
            //using people, we select the state and trim, order by state, choosing only distinct states (making this list unique),
            //we use aggregate to take the first persons state with the second persons state adding a comma in between. 
            string statesList = People
                .Select(person => person.Address.State.Trim())
                .OrderBy(state => state)
                .Distinct()
                .Aggregate((person1state, person2state) => person1state + ", " + person2state);
            return statesList;
        }           
    

}

