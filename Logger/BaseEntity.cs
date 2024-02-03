
namespace Logger;
public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; init; }

        // Explicit interface implementation for the Name property
        string IEntity.Name
        {
            get
            {
                
                throw new NotImplementedException("Implement Name Property in derived classes.");
            }
            set
            {
                
                throw new NotImplementedException("Implement Name Property in derived classes.");
            }
        }
    }