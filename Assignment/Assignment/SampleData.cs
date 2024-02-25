using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private const string CsvFilePath = "People.csv";

        // 1.
        public IEnumerable<string> CsvRows 
            => File.ReadLines(CsvFilePath).Skip(1);// This should return the entire list, Line by Line, as a string
            
         // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows
                .Select(row => row.Split(',')[6])
                .Distinct()
                .OrderBy(state => state);//This will use CsvRows, calling in one large string,
                                         //splitting it at the 6th comma, and ordering by state
        
        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());//This should combine them,
                                                                           //though selecting only states I am unsure how to do 

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                return CsvRows.Select(row =>
                {
                    var fields = row.Split(',');
                    return new Person
                    {
                        FirstName = fields[1],
                        LastName = fields[2],
                        Address = new Address(
                            streetAddress: fields[3],
                            city: fields[4],
                            state: fields[5],
                            zip: fields[6]),
                        EmailAddress = fields[7]
                    };
                }).OrderBy(p => p.Address.State)
                .ThenBy(p => p.Address.City)
                .ThenBy(p => p.Address.Zip)
                .Cast<IPerson>();// This Implementation is a total guess, but it may be close.
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) 
            => People.Where(p => filter(p.EmailAddress))
            .Select(p => (p.FirstName, p.LastName)); //This one may be right, but again a first go.

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

            return res;//This one may need to be adjusted, as I sort of guessed on the Length check.
        }
    }
}
