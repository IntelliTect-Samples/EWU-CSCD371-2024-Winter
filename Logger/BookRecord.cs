
namespace Logger;

public record class BookRecord(string Name) : IEntity
{
    // we implemented implicitly:
    // because each BookRecord object needs to have the id accessible in order to use the Get() function.
    public Guid Id { get; init; } = Guid.NewGuid();
    // we implemented explicitly:
    // because the Book record and the IEntity both have a duplicated naming convention for the Property Name.
    string IEntity.Name { 
        get {return $"{Name}";}
        }

}
