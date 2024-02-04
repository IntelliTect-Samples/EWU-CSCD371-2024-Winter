

namespace Logger;

public abstract record class BaseEntity: IEntity
{
    //Id shouldn't be accessable by the Enity itself and is only used for storage purposes
    Guid IEntity.Id { get; } = Guid.NewGuid();
    public abstract string Name { get;}



}

