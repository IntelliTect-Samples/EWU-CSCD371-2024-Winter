namespace Logger.Tests
{
    public record class Employee(string FirstName, string LastName, double Salary) : BaseEntity
    {
        public FullName EmployeeName { get; } = new FullName(FirstName, LastName);

        public double Salary { get; } = Salary;


        public override string Name => 
            $"{EmployeeName}, Salary: {Salary}";
    }
}