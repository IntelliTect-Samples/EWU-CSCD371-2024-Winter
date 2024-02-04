
namespace Logger;

public record class Student(string FirstName, string LastName) : IEntity
{

    public FullName Name { get; } = new FullName(FirstName, LastName);

    public Guid Id { get; init; }

    //Name member of IEntity should explicit becuase it has collision with Employee's name
    string IEntity.Name {get => $"{nameof(Student)}: {Name}"; }

}
