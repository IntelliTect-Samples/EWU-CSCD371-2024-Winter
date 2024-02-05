using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

// I think FullName should be reference type? Since each instance of a FullName needs identity more
// than just its values. Ex.) Two people can have the same name but are not the same people.

// I think FullName should be a mutable type? Since people can change their name. 

public record class FullName
{
    public string FirstName {  get; }
    public string? MiddleName { get; } = null;
    public string LastName { get; }

    public FullName(string firstName, string? middleName, string lastName)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(lastName);
        //middle can be null as defualt since some people dont have one, thus it should be the only nullable

        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

}
