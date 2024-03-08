using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment;

public class SampleData : ISampleData
{
    private const string FILEPATH = "People.csv";
    // 1.
    public IEnumerable<string> CsvRows
    {
        get
        {
            foreach(string lineInFile in File.ReadLines(FILEPATH).Skip(1))
            {
                yield return lineInFile;
            }
        }
    }

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        var states = CsvRows.Select(row =>
        {
            // Parse state from each row
            var state = row.Split(',')[6];
            return state.Trim(); // Trim any leading/trailing spaces
        }).Distinct(); // Ensure uniqueness

        return states.OrderBy(state => state); // Sort alphabetically
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        var statesArray = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        return string.Join(", ", statesArray);
    }

    // 4.
    public IEnumerable<IPerson> People
    {
        get
        {
            IEnumerable<IPerson> people = CsvRows
                //.Skip(1) // Skip the header row
                .Select(row => row.Split(','))
                .Select(columns => new Person(
                    columns[1], // FirstName
                    columns[2], // LastName
                    new Address(
                        columns[4], // StreetAddress
                        columns[5], // City
                        columns[6], // State
                        columns[7]  // Zip
                    ),
                    columns[3]  // EmailAddress
                ))
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip);

            return people;
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
            .Aggregate((first, second) => $"{first}, {second}");
        return string.Join(",", states);
    }
}

