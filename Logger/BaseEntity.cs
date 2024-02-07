
namespace Logger;

public abstract record class BaseEntity: IEntity
{
    //Id isn't causing any issues so it can be implicit
    public Guid Id { get; init; }

    //Name could cause naming collision so it should also be explicit
    //however trying to set it to explicit along with abstract keyword isn't working
    //So its implicit and any derrrived class and decide its implemntation
    public abstract string Name { get;}

}

