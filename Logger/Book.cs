namespace Logger;

public record class Book(string Title) : BaseEntity
{
    public override string Name { 
    get=>$"{Title}";}
    public string Title { get; } = string.IsNullOrEmpty(Title) ? throw new ArgumentNullException(nameof(Title)) : Title;

    //Implimented implicitly since Name isn't causing any collisions, and if we ever need an Author name we would
    // probably add an Author property of Entity type person which would get the Author name through that.

}
