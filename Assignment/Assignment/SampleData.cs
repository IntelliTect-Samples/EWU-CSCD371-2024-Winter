using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get 
            {
                if(!File.Exists("People.csv"))
                {
                    throw new FileNotFoundException("People.csv not found");
                }

                var fileReader = new StreamReader("People.csv");
                //Skips the 1st line in the file
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
            => throw new NotImplementedException();

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
}
