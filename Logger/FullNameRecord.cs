﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

    //names can be changed so this is mutable and should be a value type so it is checked by its value rather than its reference 
    public record class FullNameRecord
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? MiddleName { get; }

        public FullNameRecord(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            MiddleName = middleName;
        }

        public FullNameRecord(string firstName,  string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            MiddleName = null;
        }

    public override string ToString()
    {
        if (MiddleName != null)
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
        else
        {
            return $"{FirstName} {LastName}";
        }
    }
}
