namespace Logger;
public interface IEntity
{
        // Place members here.
        public Guid Id { get;  init; }
        public string Name { get; set; }
}
