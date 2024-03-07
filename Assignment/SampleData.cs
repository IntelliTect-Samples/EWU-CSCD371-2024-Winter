
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
            
            return CsvRows.Select(item => item.Split(',')[6])
               .OrderBy(state => state)
               .Distinct();
            
        }
    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        var uniqueStates = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        return string.Join(", ", uniqueStates);
    }

    // 4.
    public IEnumerable<IPerson> People
        {
            get
            {
                var people = from line in CsvRows
                             let elements = line.Split(',')
                             let address = new Address(elements[4], elements[5], elements[6], elements[7])
                             select new Person(elements[1], elements[2], address, elements[3]);

                return people.OrderBy(person => (person.Address.City, person.Address.State, person.Address.Zip));
            }
        }


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

