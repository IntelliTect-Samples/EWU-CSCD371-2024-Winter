using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

// I think FullName should be reference type? Since each instance of a FullName needs identity more
// than just its values. Ex.) Two people can have the same name but are not the same people.

// I've changed this to a value type since it is more or less just a simple variable, the entities that
// FullName will apply to should handle the uniqueness of the object.

// I think FullName should be a mutable type? Since people can change their name. 

public record struct FullName
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

    public override string ToString()
    {   //we definetly talked about a more effcient way in class but this works at least...
        if(MiddleName != null)
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
        else
        {
            return FirstName + " " + LastName;
        }
    }

}
