namespace Logger;



// I've changed this to a value type since it is more or less just a simple variable, the entities that
// FullName will apply to should handle the uniqueness of the object.

// FullName is a immutable type due to the fact of readonly

public readonly record struct FullName(string firstName, string lastName, string? middleName = "")
{
    public string FirstName { get; } = firstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string MiddleName { get; } = middleName ?? "";
    public string LastName { get; } = lastName ?? throw new ArgumentNullException(nameof(LastName));

    public override string ToString()
    {
    return $"{firstName}{(string.IsNullOrWhiteSpace(middleName) ? String.Empty : " +  middleName)} {LastName}")}";
    }

}
