using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger {

    public readonly record struct FullNameRecord
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? MiddleName { get; }

        public FullNameRecord(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }



    }
}