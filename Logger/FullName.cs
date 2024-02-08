namespace Logger;



// I've changed this to a value type since it is more or less just a simple variable, the entities that
// FullName will apply to should handle the uniqueness of the object.

// FullName is a immutable type due to the fact of readonly

public readonly record struct FullName(string FirstName, string LastName, string? MiddleName = "")
{
    public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string MiddleName { get; } = MiddleName ?? "";
    public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));

    public override string ToString()
    {
    return $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? String.Empty : " +  MiddleName)} {LastName}")}";
    }

}
