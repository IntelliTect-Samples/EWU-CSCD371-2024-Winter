namespace Logger;

public record class Book(string Title, long? Isbn) : IEntity
{
    public string Title { get; init; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public long? Isbn { get; init; } = Isbn ?? throw new ArgumentNullException(nameof(Isbn));
    //Implicit, Id doesn't cause any issues
    public Guid Id { get; init; }
    //Implicit, Name doesn't cause issues with collision
    public string Name { get => $"EntityType: {nameof(Book)}, EntityID: {Id}, Title: {Title}, ISBN: {Isbn}"; }

    public override string ToString() => $"Title: {Title}, ISBN: {Isbn}";

}

