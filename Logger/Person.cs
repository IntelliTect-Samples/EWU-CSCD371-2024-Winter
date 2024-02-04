
namespace Logger;

public abstract record class Person(string FirstName, string LastName)
{
    public FullName Name { get; set; } = new FullName(FirstName, LastName);

    public override string ToString() => Name.ToString();


}

