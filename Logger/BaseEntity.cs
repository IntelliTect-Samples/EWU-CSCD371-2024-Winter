
namespace Logger;

// We implemented the interface implicitly because the BaseEntity has a can-do relationship with IEntity
public abstract record class BaseEntity : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public abstract string Name { get; }
}
