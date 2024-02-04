
namespace Logger.Tests
{
    public record class Employee(string FirstName, string LastName) : IEntity
    {
        public FullName Name { get; } = new FullName(FirstName, LastName);


        //Name member of IEntity should explicit becuase it has collision with Employee's name
        string IEntity.Name {get=> $"{nameof(Employee)}: {Name}"; }

        public Guid Id { get; init; }

    }
}