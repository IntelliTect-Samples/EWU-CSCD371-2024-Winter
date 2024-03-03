using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment;

public class SampleDataAsync : IAsyncSampleData
{
    public IAsyncEnumerable<string> CsvRows => throw new NotImplementedException();

    public IAsyncEnumerable<IPerson> People => throw new NotImplementedException();

    public IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        throw new NotImplementedException();
    }

    public string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
    {
        throw new NotImplementedException();
    }

    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        throw new NotImplementedException();
    }
}
