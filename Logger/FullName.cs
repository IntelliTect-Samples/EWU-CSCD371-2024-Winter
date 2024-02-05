namespace Logger;

namespace Logger;

public record FullName(string FirstName, string? MiddleName, string LastName)
{
    // We chose record because it is both Immutable and it has valuie equality behavior.
    // Records are immutable because they cannot be changed once created.
}