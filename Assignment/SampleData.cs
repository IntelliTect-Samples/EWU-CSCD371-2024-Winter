﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Assignment;

public class SampleData(string FileSource) : ISampleData
{
    // this should be updated depending on how you do checking
public string FileSource {get;} = FileSource is null ? throw new ArgumentNullException(nameof(FileSource)) : File.Exists(FileSource) ? FileSource : throw new ArgumentException(nameof(FileSource));
    // 1.
    public IEnumerable<string> CsvRows { get; } = File.ReadAllLines("People.csv").Skip(1);
    //skip the first row

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows.Select(item => item.Split(',')[6])
        .OrderBy(state => state)
               .Distinct();//for unique
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        return string.Join(", ",GetUniqueSortedListOfStatesGivenCsvRows().ToArray()); 
    }

    // 4.
    public IEnumerable<IPerson> People => CsvRows.Select(item => item.Split(','))
                                         .OrderBy(split => (split[6],split[5],split[7]))
                                         .Select(split => new Person(split[1], split[2],
                                                                      new Address(split[4], split[5], split[6], split[7]),
                                                                      split[3]));
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter) => People.Where(person => filter(person.EmailAddress))
                                            .Select(person => (person.FirstName, person.LastName));

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
       return people.Select(person => person.Address.State).Distinct()
                                                        .Aggregate((state, next) => state + ", " + next);
    }
}