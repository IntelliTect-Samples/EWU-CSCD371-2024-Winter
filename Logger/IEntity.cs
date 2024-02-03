namespace Logger;
public interface IEntity
{

        // Place members here.
        Guid Id { get; init; }
        string Name { get; set; }

}
