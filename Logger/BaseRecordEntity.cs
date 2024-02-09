namespace Logger;

public abstract record class BaseRecordEntity(string Name): IEntity
{
    // Name is implemented implicitly, since BaseRecordEntity only implements one interface
    public string Name { get; set; } = Name;
    // Guid is implemented implicitly, since BaseRecordEntity only implements one interface
    public Guid Id { get; init; } = Guid.NewGuid();
}

