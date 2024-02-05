using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    //as a name can be changed this is not immutable and should be a reference type so it's dynamic
    public record class FullNameRecord
    {
        private string FirstName { get; }
        private string LastName { get; }
        private string? MiddleName { get; }

        public FullNameRecord(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public FullNameRecord(string firstName,  string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = null;
        }

        public override string ToString()
        {
            if(MiddleName != null)
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
            else
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
