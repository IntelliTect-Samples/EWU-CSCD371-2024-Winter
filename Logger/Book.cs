namespace Logger;

public record class Book(string Title, string Author) : IEntity
{
    public string Title { get; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; } = Author ?? throw new ArgumentNullException(nameof(Author));

    public Guid Id { get; init; }

    public string Name { get => $"{nameof(Book)}: {Title} By {Author}"; }


}

