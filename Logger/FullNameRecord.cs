namespace Logger;
//Why its a Value Type:
// The reason we decided to use a value type is because it logically represents a single value.
// Another reason this is a value type is because this record does not need to be inherited.
//Why its Immutable:
// The reason this struct is immutable is because it is a value type and value types must be immutable. 
// Here the readonly modifier ensures that the record is immutable.
public readonly record struct FullNameRecord(string First, string Last, string? Middle = null)
{
    public readonly string First { get; init; } = First ?? throw new ArgumentNullException(nameof(First));
    public readonly string Last { get; init; } = Last ?? throw new ArgumentNullException(nameof(First));
    public readonly string? Middle { get; init; } = Middle;

    public override string ToString()
    {
        if(string.IsNullOrEmpty(Middle))
        {
            return $"{First} {Last}";
        }
        else
        {
            return $"{First} {Middle} {Last}";
        }
    }
}
