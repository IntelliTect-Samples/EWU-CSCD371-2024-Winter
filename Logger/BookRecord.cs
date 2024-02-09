
namespace Logger;

public record class BookRecord(string ClassName) : BaseEntity
{
    
    // We implemented the Name property implicitly because it is an is-a relationship 
    public override string Name 
    {
        get 
        {
            return $"{ClassName}";
        }
    }

    public string ClassName {get; set;} = ClassName ?? throw new ArgumentNullException(nameof(ClassName));
}
