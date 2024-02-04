
namespace Logger;

public abstract record class BaseEntity: IEntity
{
    //Id shouldn't be accessable by the Enity itself and is only used for storage purposes
    //Also could cause conflict with Ids of actual enity that isn't involved with storage
    public Guid Id { get; init; } = Guid.NewGuid();

    //Name could cause naming collision so it should also be explicit
    public abstract string Name { get;}

    public virtual bool Equals(BaseEntity? other)
    {
        return (Name).Equals(
        (other?.Name));
    }

    public override int GetHashCode() =>
    (Name).GetHashCode();
}

