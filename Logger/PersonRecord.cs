
namespace Logger;

public record class PersonRecord(string ClassName) : BaseEntity
{
    public PersonRecord(string ClassName, FullNameRecord FullName) : this(ClassName){
        this.FullName = FullName;
    }

    /// We implemented the Name property implicitly because it is an is-a relationship 
    public override string Name 
    {
        get 
        {
            return $"{ClassName}" ?? throw new ArgumentNullException(nameof(ClassName));
        }
    }

    public FullNameRecord FullName {get; set;}
}
