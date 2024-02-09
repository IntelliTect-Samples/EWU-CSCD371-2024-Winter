namespace Logger;

// The Employee record inherits the PersonRecord where all of the refactored code was moved.
public record class EmployeeRecord(string ClassName) : PersonRecord(ClassName)
{
	public EmployeeRecord(string ClassName, FullNameRecord FullName) : this(ClassName) 
	{
		FullNameRecord = FullName;
	}
}
