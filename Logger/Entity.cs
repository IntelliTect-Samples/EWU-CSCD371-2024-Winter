

namespace Logger;

public abstract class Entity : IEntity
{
    Guid IEntity.Id { get; init; }
    public abstract string Name { get; set; }
}

