﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logger;


    public record FullName
    {
        //Fullname encompasses three parts usually a first, middle and last name a constructor with 
        //these three/two requirements is what is need when instantiate a new person
        //Records are immutable and so FullName should reflect that as first, middle, and last names do
        //not change in real life unless some legal entity supercedes that.
        public FullName(string firstName, string lastName, string? middleName = null)
        {
            FirstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            MiddleName = middleName;
           
        

        }

    public string FirstName { get; set; }
        public string LastName { get; set; }
    public string? MiddleName { get; set; }
        
        public string Name { get { return FirstName + $"{(MiddleName != null ? " " + MiddleName + " " : " ")}" + LastName; } }  
        
    }