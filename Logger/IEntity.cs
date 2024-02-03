namespace Logger;
public interface IEntity
{

        // Place members here.
        Guid ID { get;  init; }
        string Name { get; set; } //should be ok
}
