using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Interfaces;
public interface IAddress
{
    string StreetAddress { get; }
    string City { get; }
    string State { get; }
    string Zip { get; }
}
