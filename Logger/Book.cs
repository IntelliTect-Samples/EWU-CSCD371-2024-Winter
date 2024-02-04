namespace Logger;

public record class Book(string Title, string Author) : IEntity
{
    public string Title { get; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; } = Author ?? throw new ArgumentNullException(nameof(Author));

    public Guid Id { get; init; }

    public string Name { get => $"{nameof(Book)}: {Title} By {Author}"; }

    public virtual bool Equals(Book? other)
    {
        return Name.Equals(
        (other?.Name));
    }

    public override int GetHashCode() =>
    (Name).GetHashCode();



}

