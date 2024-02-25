using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Assignment;

public class SampleData : ISampleData
{
    private IEnumerable<string> _CsvRows = [];
    // 1.
    public IEnumerable<string> CsvRows => _CsvRows;

    public int Columns { get; init; } = 0;

    /// <summary>
    /// FromCsvString validates CSV-formated data and returns a container object
    /// </summary>
    /// <param name="csv">a CSV string</param>
    /// <returns>an object containing the lines</returns>
    /// <exception cref="Exception"></exception>
    public static SampleData FromCsvString(string csv) {
        ArgumentException.ThrowIfNullOrEmpty(csv);
        string[] lines = csv.Split("\n");
        int columns = lines.First().Split(",").Length;
        IEnumerable<string> data = lines.Skip(1);

        // check for column consistency
        // TODO: account for quoted commas
        int l = 1;
        foreach(string line in data)
        {
            int lineColumns = line.Split(",").Length;
            if(lineColumns != columns)
            {
                throw new Exception($"Unable to parse csv, inconsistent number of columns ({lineColumns} != {columns} on line {l})");
            }
            l++;
        }

        return new()
        {
            Columns = columns,
            _CsvRows = data
        };
    }

    /// <summary>
    /// FromFile takes a file path as input, validating it and returning a container. Because it
    /// does not keep the stream open as an object, the IDisposable pattern is not needed
    /// </summary>
    /// <param name="path">path to a CSV-formated file</param>
    /// <returns>an object containing the lines</returns>
    public static SampleData FromFile(string path) =>
        FromCsvString(File.ReadAllText(path));

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()  =>
        CsvRows.Distinct().Order();

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
