namespace Logger;

// The Employee record inherits the PersonRecord where all of the refactored code was moved.
public record class EmployeeRecord(FullNameRecord FullName) : PersonRecord(FullName)
{
    public EmployeeRecord(string First, string Last, string Middle) : this(new FullNameRecord(First, Last, Middle)){}

    public EmployeeRecord(string First, string Last) : this(new FullNameRecord(First, Last)){}
}
