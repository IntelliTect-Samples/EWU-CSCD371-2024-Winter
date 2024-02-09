
namespace Logger;

// We implemented the interface implicitly because the BaseEntity has a cando relationtip with IEntity
public abstract class BaseEntity : IEntity
{
    public Guid Id { get; init; }
    public abstract string Name { get; }
}
