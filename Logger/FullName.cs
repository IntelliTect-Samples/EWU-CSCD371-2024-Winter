namespace Logger;

// We selected a class (reference type) for FullName to allow handling null values and make it mutable
// This is useful for scenarios where only parts of the full name are known or can be null
// FullName is mutable to allow modification
// This is useful in scenarios where the full name might be updated independently
public class FullName
{
    public string? First { get; }
    public string? Last { get; }
    public string? Middle { get; }

    public FullName(string? first, string? last, string? middle)
    {
        First = first;
        Last = last;
        Middle = middle;
    }
}