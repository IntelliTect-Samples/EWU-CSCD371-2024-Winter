
namespace Logger;

public record class Student(string FirstName, string LastName) : IEntity
{

    public FullName Name { get; } = new FullName(FirstName, LastName);

    public Guid Id { get; init; }

    //Name member of IEntity should explicit becuase it has collision with Employee's name
    string IEntity.Name {get => $"{nameof(Student)}: {Name}"; }

    public virtual bool Equals(Book? other)
    {
        return Name.Equals(
        (other?.Name));
    }

    public override int GetHashCode() =>
    (Name).GetHashCode();

}
