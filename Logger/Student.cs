namespace Logger;

//Implemented name implicitly, explination in Person class
public record class Student : Person
{
    public Student(FullName name) : base(name) { }
}
