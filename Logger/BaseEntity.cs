namespace Logger;

public abstract record class BaseEntity : IEntity
{
    //I think we should implement Id explicitly since Entities like Student may later have a Student Id which could be confusing.
    //However our project then runs into the problem where we cannot get a derived entity's Id since it has to be marked private.
    // This caused problems in StorageTests when testing the Get method...
    public Guid Id { get; init; } = Guid.NewGuid();
    //Guid IEntity.Id { get; init; } = Guid.NewGuid();
    public abstract string Name { get; }

}
