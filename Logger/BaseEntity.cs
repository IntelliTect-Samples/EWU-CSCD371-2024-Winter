

namespace Logger;

public abstract record class BaseEntity: IEntity
{
    public Guid Id { get; } = Guid.NewGuid();
    public abstract string Name { get; }



}

