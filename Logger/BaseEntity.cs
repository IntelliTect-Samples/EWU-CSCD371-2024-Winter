
namespace Logger;

public abstract record class BaseEntity: IEntity
{
    //Id shouldn't be accessable by the Enity itself and is only used for storage purposes
    //Also could cause conflict with Ids of actual enity that isn't involved with storage
    Guid IEntity.Id { get; init; }

    //Name could cause naming collision so it should also be explicit
    public abstract string Name { get;}

}

