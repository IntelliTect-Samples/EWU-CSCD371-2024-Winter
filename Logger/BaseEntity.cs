
namespace Logger;
public abstract record class BaseEntity : IEntity
    {
        public Guid Id { get; init; }

        // Explicit interface implementation for the Name property
        string IEntity.Name
        {
            

            //throw new NotImplementedException("Implement Name Property in derived classes.");
            get => getName();  set => SetName(value);
           
           
        }
    public abstract string getName();
    public abstract void SetName(string name);

    }