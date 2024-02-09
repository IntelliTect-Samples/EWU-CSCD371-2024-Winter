namespace Logger;

//Implimented implicitly since Name isn't causing any collisions, and if we ever need an Author name we would
// probably add an Author property of Entity type person which would get the Author name through that.

public record class Book(string Title) : BaseEntity
{
    //TODO FIX
    public string Title {get;} = Title ?? ArgumentNullException.ThrowIfNull(nameof(title));
    public override string Name { 
    get=>$"{Title}";}
}
