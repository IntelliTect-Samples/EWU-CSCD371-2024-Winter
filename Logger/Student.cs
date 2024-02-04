namespace Logger;

public record class Student(string FirstName, string LastName, int ID) : BaseEntity
{

    public FullName StudentName { get; } = new FullName(FirstName, LastName);

    public int ID { get; } = ID;

    public override string Name => $"{ID}: {StudentName}";

}
