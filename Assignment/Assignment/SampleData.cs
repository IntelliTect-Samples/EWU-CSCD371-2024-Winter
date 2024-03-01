using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);//Skip the header

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
        {
          // Select the state column and trim just to have states
          // Make sure each part in the list is Distinct
          // Order by state name alphebetically 
          return CsvRows
            .Select(row => row.Split(',')[6].Trim())
            .Distinct()
            .OrderBy(state => state, StringComparer.OrdinalIgnoreCase);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
          // Get IEnumerable list of states from previous fucntion
          IEnumerable<string> uniqueStates = GetUniqueSortedListOfStatesGivenCsvRows();

          // Create a string and use join to join all parts of the lisr
          string result = string.Join(", ", uniqueStates);
          return result;
        }

        // 4.
        public IEnumerable<IPerson> People 
        {
          get 
          {
            
            var peopleList = CsvRows
              .OrderBy(row => row.Split(',')[6].Trim(), StringComparer.OrdinalIgnoreCase)
              .ThenBy(row => row.Split(',')[5].Trim(), StringComparer.OrdinalIgnoreCase)
              .ThenBy(row => row.Split(',')[7].Trim())
              .Select(row => row.Split(','))
              .Select(column => new Person(
                    column[1].Trim(), // First Name
                    column[2].Trim(), // Last name
                    new Address(
                      column[4].Trim(), // Street
                      column[5].Trim(), // City
                      column[6].Trim(), // State
                      column[7].Trim()  // Zip
                      ),
                    column[3].Trim() // email 
              ));
            /*
              .OrderBy(person => person.Address.State, StringComparer.OrdinalIgnoreCase)
              .ThenBy(person => person.Address.City, StringComparer.OrdinalIgnoreCase)
              .ThenBy(person => person.Address.Zip);
            */
            return peopleList;
          }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }

}
