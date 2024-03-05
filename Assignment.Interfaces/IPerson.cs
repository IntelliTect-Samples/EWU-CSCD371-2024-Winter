using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Interfaces;
public interface IPerson
{
    string FirstName { get; }
    string LastName { get; }
    IAddress Address { get; }

    string EmailAddress { get; }
}

