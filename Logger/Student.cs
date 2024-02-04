
namespace Logger;

public record class Student(string FirstName, string LastName, int ID) : IEntity
{

    public FullName StudentName { get; } = new FullName(FirstName, LastName);

    public int ID { get; } = ID;
    public Guid Id { get; init; }

    public string Name {get => $"{ID}: {StudentName}"; }

    public virtual bool Equals(Book? other)
    {
        return Name.Equals(
        (other?.Name));
    }

    public override int GetHashCode() =>
    (Name).GetHashCode();

}
