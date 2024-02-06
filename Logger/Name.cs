namespace Logger;


public record Name(string FirstName, string? MiddleName, string LastName)
{
    public static Name Create(string FirstName, string? MiddleName, string LastName)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
        {
            throw new ArgumentException("First name cannot be empty or null.", nameof(FirstName));
        }

        if(string.IsNullOrWhiteSpace(LastName))
        {
            throw new ArgumentException("Last name cannot be empty or null.", nameof (LastName));
        }

        if(string.IsNullOrWhiteSpace(MiddleName)) 
        {
            return new Name(FirstName, "", LastName);
        }
       
        return new Name(FirstName, MiddleName, LastName);

    }
    // Went with factory method, as this streamlines name creation and implements Null and Empty checks easily. 
    // Middle Name was declared nullable because some people do not have middle names, and thus sometimes middle name will be null.
    // We chose record because it is both Immutable and it has value equality behavior.
    // Records are immutable because they cannot be changed once created.

}