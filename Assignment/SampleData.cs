using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Xml;
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
            // Read CSV rows from CsvRows property
            var csvRows = CsvRows;

            // Extract states and remove duplicates
            var stateSet = new HashSet<string>();
            foreach (var row in csvRows)
            {
                var columns = row.Split(',');
                if (columns.Length >= 7) // Assuming state is at index 6
                {
                    stateSet.Add(columns[6].Trim()); // Trim to remove any extra spaces
                }
            }

            // Convert to a list and sort alphabetically
            var sortedStates = new List<string>(stateSet);
            sortedStates.Sort(StringComparer.OrdinalIgnoreCase); // Case-insensitive sorting

            return sortedStates;
        }

        //2 OVEROAD FOR TESTING
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows(IEnumerable<string>? addresses = null)
        {
            IEnumerable<string> csvRows;

            if (addresses == null)
            {
                csvRows = CsvRows;
            }
            else
            {
                csvRows = addresses;
            }

            var stateSet = new HashSet<string>();
            foreach (var row in csvRows)
            {
                var columns = row.Split(',');
                if (columns.Length >= 7)
                {
                    stateSet.Add(columns[6].Trim());
                }
            }

            var sortedStates = stateSet.OrderBy(s => s, StringComparer.OrdinalIgnoreCase);

            return sortedStates;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            // Get unique, sorted list of states
            var uniqueSortedStates = GetUniqueSortedListOfStatesGivenCsvRows();

            // Select only the state names and convert to array
            var stateNamesArray = uniqueSortedStates.Select(state => state.Split(',')[6].Trim()).ToArray();

            // Convert array of state names into a comma separated string
            string aggregatedStates = string.Join(",", stateNamesArray);

            return aggregatedStates;
        }


        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                Address address;

                //going through the csv file and splitting everything to save into variable we can use for the adress to order by it
                //we will return a person with first name, last name, address, email 
                //using this person, we order by the state, then by the city and then by the zip code for each person 
                //giving us a list of sorted people by address
                IEnumerable<IPerson> sorted = CsvRows.Skip(1)
                .Select(rows =>
                {
                    string[] col = rows.Split(",");
                    if (col.Length >= 8){
                    string firstName = col[1];
                    string lastName = col[2];
                    string email = col[3];
                    string streetAdd = col[4];
                    string city = col[5];
                    string state = col[6];
                    string zip = col[7];

                    address = new(streetAdd, city, state, zip);
                    Person person = new(firstName, lastName, address, email);
                    return person;
                    }
                    else
                    {
                    return null!;
                    }
                })
                .Where(person => person != null) // Filter out null entries
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip);

                return sorted;
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
                .OrderByDescending(state => state)
                .Distinct()
                .Aggregate((person1state, person2state) => person1state + "," + person2state);
            return statesList;
        }           
    }
