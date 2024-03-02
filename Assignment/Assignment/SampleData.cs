using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows => File.ReadLines("People.csv").Skip(1);

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        => CsvRows.Select(row => row.Split(',')).Select(row => row[6]).Distinct().OrderBy(state => state);

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
        => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

    // 4.
    public IEnumerable<IPerson> People => CsvRows.Select(line => line.Split(","))
        .OrderBy(line => line[5])
        .ThenBy(line => line[6])
        .ThenBy(line => line[7])
        .Select(line => new Person(line[1], line[2], new Address(line[4], line[5], line[6], line[7]), line[3]));

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter) => People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
        
        => string.Join(", ",people
        .Aggregate(new HashSet<string>(),
            (set, person)
            =>
            {
                if (!set.Contains(person.Address.State))
                    set.Add(person.Address.State);

                return set;
            }));
        
}

