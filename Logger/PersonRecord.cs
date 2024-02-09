
namespace Logger;

public record class PersonRecord(FullNameRecord FullName) : BaseEntity
{
    public PersonRecord(string First, string Last, string Middle) : this(new FullNameRecord(First, Last, Middle))
    {

    }

    public PersonRecord(string First, string Last) : this(new FullNameRecord(First, Last))
    { 
    }

    // Implicit Implementation:
    // Because it makes logical sense for the StudentRecord to have easy access to the name property.
    public override string Name { get; } = FullName.ToString();
}
