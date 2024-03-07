using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment;

public class SampleData : ISampleData
{
    private const string CsvFilePath = "People.csv";

    // 1.
    public IEnumerable<string> CsvRows
    {
        get 
        {
            if (!File.Exists(CsvFilePath))
            {
                throw new FileNotFoundException(nameof(CsvFilePath));
            }
            return File.ReadLines(CsvFilePath).Skip(1);// This should return the entire list, Line by Line, as a string
        }
    }

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
       => CsvRows
            .Select(row => row.Split(','))
            .Where(fields => fields.Length > 4)
            .Select(fields => fields[4].Trim())
            .Where(state => !string.IsNullOrEmpty(state))
            .Distinct()
            .OrderBy(state => state);


    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        var sortedUniqueStates = GetUniqueSortedListOfStatesGivenCsvRows()
            .ToArray();

        return string.Join(",", sortedUniqueStates);
    }

    // 4.
    public IEnumerable<IPerson> People
    {
        get
        {
            return CsvRows.Select(row => row.Split(','))
                .Where(fields => fields.Length >= 7)
                .Select(fields =>
            {
                
                return new Person 
        (
            firstName: fields[0],
            lastName: fields[1],
            address: new Address(
                streetAddress: fields[2],
                city: fields[3],
                state: fields[4],
                zip: fields[5]),
            emailAddress: fields[6]
        );

            })
    .Where(person => person != null) //This gets rid of null entries
    .OrderBy(p => p.Address.State)
    .ThenBy(p => p.Address.City)
    .ThenBy(p => p.Address.Zip)
    .Cast<IPerson>();
        }
    }

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter)
    {
        return filter == null
            ? throw new ArgumentNullException(nameof(filter))
            : People.Where(p => p.EmailAddress != null && filter(p.EmailAddress))
            .Select(p => (p.FirstName, p.LastName));
    } 

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
        var uniqueSortedStates = people
            .Select(person => person.Address.State)
            .Distinct()
            .OrderBy(state => state);

        string res = uniqueSortedStates
            .Aggregate(new StringBuilder(), (sb, state) => sb.Append(sb.Length == 0 ? "" : ",").Append(state))
            .ToString();

        return res;
    }
}
