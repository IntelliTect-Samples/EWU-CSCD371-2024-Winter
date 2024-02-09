namespace Logger;

public abstract record class Person : BaseEntity
{
    //Implemented Name implcitily since FullName is never saved as a property itself so it cant be accessed, so no conflicts
    public override string Name { get; }

    public Person(FullName name)
    {
        Name = name.ToString();
    }
}
