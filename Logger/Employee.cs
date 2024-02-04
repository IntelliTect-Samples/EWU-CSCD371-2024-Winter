
namespace Logger.Tests
{
    public record class Employee(string FirstName, string LastName, double Salary) : IEntity
    {
        public FullName EmployeeName { get; } = new FullName(FirstName, LastName);

        public double Salary { get; } = Salary;


        public string Name {get=> $"{EmployeeName}, Salary: {Salary}"; }
            
        public Guid Id { get; init ; }

        public virtual bool Equals(Book? other)
        {
            return Name.Equals(
            (other?.Name));
        }

        public override int GetHashCode() =>
        (Name).GetHashCode();

    }
}