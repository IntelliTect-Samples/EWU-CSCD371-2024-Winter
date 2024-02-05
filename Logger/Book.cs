namespace Logger;

public record class Book(string Title, string Author) : IEntity
{
    public string Title { get; init; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; init; } = Author ?? throw new ArgumentNullException(nameof(Author));
    //Implicit, Id doesn't cause any issues
    public Guid Id { get; init; }
    //Implicit, Name doesn't cause issues with collision
    public string Name { get => $"{nameof(Book)}: {Title} By {Author}"; }

    public override string ToString() => $"{Title} By {Author}";

}

