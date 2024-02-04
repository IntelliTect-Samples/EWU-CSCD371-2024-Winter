namespace Logger;

public record class Book(string Title, string Author) : BaseEntity
{
    public string Title { get;  } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string Author { get; } = Author ?? throw new ArgumentNullException(nameof(Author));

    public override string Name { get =>
            $"{Title} By {Author}";
       
    }
}

