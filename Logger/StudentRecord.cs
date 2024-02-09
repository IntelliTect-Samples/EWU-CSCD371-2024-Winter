namespace Logger;

// A StudentRecord class inherits from the PersonRecord base class and passes a constructor call to it.
// For this class implementation, see PersonRecord
public record class StudentRecord(string ClassName) : PersonRecord(ClassName)
{
    public StudentRecord(string ClassName, FullNameRecord FullName) : this(ClassName)
    {
        FullNameRecord = FullName;
    }
}
