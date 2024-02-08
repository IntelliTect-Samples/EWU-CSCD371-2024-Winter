namespace Logger;

//Implemented name implicitly, explination in Person class
public record class Employee : Person
{
    public Employee(FullName name) : base(name) { }

}
