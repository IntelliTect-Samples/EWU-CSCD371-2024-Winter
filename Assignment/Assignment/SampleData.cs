using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment;

public class SampleData : ISampleData
{
    public readonly string FilePath = Path.Combine(Environment.CurrentDirectory, "People.csv"); //this also needs fixing
    // 1.
    public IEnumerable<string> CsvRows
    {
        get 
        {
            if(File.Exists(FilePath) == false) //needs fixed
            {
                throw new FileNotFoundException($"File not found in path: {FilePath}");
            }

            var fileReader = new StreamReader(FilePath);
            
            //Skips the 1st line of the file
            fileReader.ReadLine();

            while(!fileReader.EndOfStream)
            {
                string? data = fileReader.ReadLine();
                
                if (data != null)
                {
                    yield return data;
                }
            }

        }
    }

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[6])
            .Distinct()
            .OrderBy(state => state).ToList(); 
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows() 
    {
        return string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());
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
