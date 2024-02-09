namespace Logger;
public interface IEntity
{
        // Place members here.
        public Guid ID { get;  init; }
        public abstract string Name { get; }
}
