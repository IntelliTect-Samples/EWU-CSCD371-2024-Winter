
namespace Logger;

public record class BookRecord(string ClassName) : BaseEntity
{
    
    // we implemented explicitly:
    // because the Book record and the IEntity both have a duplicated naming convention for the Property Name.
    public override string Name 
    {
        get 
        {
            return $"{ClassName}" ?? throw new ArgumentNullException(nameof(ClassName));
        }
    }
}
