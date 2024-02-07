
namespace Logger;

public record class Person(string FirstName, string LastName)
{
    public FullName Name { get;} = new FullName(FirstName, LastName);

    public override string ToString() => Name.ToString();

}

